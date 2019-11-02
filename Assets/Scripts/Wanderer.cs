﻿using UnityEngine;
using System.Collections;

public class Wanderer : MonoBehaviour
{


    // public vars
    public float rotateSpeed = 1;
    public float walkSpeed = 6;
    public LayerMask groundedMask;

    // System vars
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Rigidbody rigidbody;

    Collider col;


    Transform sun;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Start()
    {
        sun = FindObjectOfType<Sun>().transform;
    }

    void Update()
    {


        // Calculate movement:
        float inputX = Mathf.Cos(Time.time);
        float inputY = Mathf.Sin(Time.time);

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
}