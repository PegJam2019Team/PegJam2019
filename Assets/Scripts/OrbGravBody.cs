using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class OrbGravBody : MonoBehaviour
{

    GravityAttractor planet;
    Rigidbody rigidbody;
    public bool isDark;

    public AudioClip collect;

    void Awake()
    {
        planet = GameObject.FindGameObjectWithTag(isDark? "Moon":"Sun").GetComponent<GravityAttractor>();
        rigidbody = GetComponent<Rigidbody>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.AddForce(transform.up * 50f, ForceMode.Impulse);

        AudioSource.PlayClipAtPoint(collect, transform.position, 1f);
    }

    void FixedUpdate()
    {
        // Allow this body to be influenced by planet's gravity
        planet.Attract(rigidbody);

        transform.position = Vector3.MoveTowards(transform.position, planet.transform.position , 20 * Time.deltaTime);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == planet.transform)
        {
            Destroy(gameObject);
        }
    }
}