using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wanderers;
    public float spawnTime = 10;
    public float spawnTimer = 0;
    private int spawnTypeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnOrdered();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnTime)
        {
            SpawnOrdered();
            spawnTimer = 0;
        }
    }

    public void SpawnRandom()
    {
        Instantiate(wanderers[Random.Range(0, 2)], Random.onUnitSphere * 35, Quaternion.identity);
    }

    public void SpawnOrdered()
    {
        Instantiate(wanderers[spawnTypeIndex], Random.onUnitSphere * 35, Quaternion.identity);
        spawnTypeIndex++;
        if(spawnTypeIndex == 2)
        {
            spawnTypeIndex = 0;
        }
    }
}
