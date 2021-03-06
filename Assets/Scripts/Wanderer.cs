﻿using UnityEngine;
using System.Collections;

public class Wanderer : MonoBehaviour
{
    // public vars
    public float rotateSpeed = 1;
    private float walkSpeed = 6;
    public LayerMask groundedMask;
    public GameObject CollectedOrb;

    float wanderTime = 2f, wanderTimer = 0f;
    float wanderInputX, wanderInputY;

    // System vars
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    Rigidbody rigidbody;

    Collider col;
    LightActivator activator;

    Transform sun;

    public delegate void OnCollectDelegate(bool isDark);
    public static event OnCollectDelegate OnCollectWanderer;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        activator = GetComponent<LightActivator>();
    }

    void Start()
    {
        sun = FindObjectOfType<Sun>().transform;
    }

    void Update()
    {
        wanderTimer += Time.deltaTime;

        if(wanderTimer >= wanderTime)
        {
            wanderInputX = Random.Range(-1f, 1f);
            wanderInputY = Random.Range(-1f, 1f);

            wanderTimer = 0f;
        }
        // Calculate movement:
        float inputX = wanderInputX;
        float inputY = wanderInputY;

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

    }

    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null && activator.Active)
        {
            //particle hit, send off to sun or moon
            //sounds
            //event
            if (OnCollectWanderer != null)
            {
                OnCollectWanderer(activator.isDark);
            }

            Instantiate(CollectedOrb, transform.position, transform.rotation);
            
            Destroy(gameObject);
        }
    }
}