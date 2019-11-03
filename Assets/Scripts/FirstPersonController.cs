using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GravityBody))]
public class FirstPersonController : MonoBehaviour
{

    private Animator anim;

    // public vars
    public float rotateSpeed = 1;
    public float walkSpeed = 6;
    public float jumpForce = 220;
    public LayerMask groundedMask;

    // System vars
    bool grounded;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Rigidbody rigidbody;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {        
        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // Look rotation:
        transform.Rotate((Vector3.up * inputX) * rotateSpeed);

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        if(targetMoveAmount.magnitude == 0)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
        }
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rigidbody.AddForce(transform.up * jumpForce);
            }
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }

    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
    }
}