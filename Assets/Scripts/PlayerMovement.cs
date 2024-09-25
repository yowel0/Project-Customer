using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public enum MovementType{
        SetVelocity,
        AddForce
    }
    public MovementType movementType = MovementType.SetVelocity;
    Rigidbody rb;
    
    //input
    Vector2 input;

    //looking
    Transform cameraTransform;
    bool firstPerson = false;

    //jumping
    LayerMask mask;
    [Header("Jumping")]
    public bool canJump;
    public float jumpHeight;

    public AudioSource footsteps;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;

        if (cameraTransform.IsChildOf(transform)){
            firstPerson = true;
        }

        mask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        input.Normalize();
        if (!footsteps.isPlaying && input.magnitude > 0){
            footsteps.Play();
        }
        else if (footsteps.isPlaying && input.magnitude == 0){
            footsteps.Pause();
        }

        //if Camera active as child in player > make the mouse rotate camera and player
        if (firstPerson){
            Look();
        }

        if (canJump){
            Debug.DrawRay(transform.position - new Vector3(0,transform.localScale.y,0), Vector3.down* .5f);
            if(Physics.Raycast(transform.position - transform.localScale / 2, Vector3.down, .5f,mask) && Input.GetKeyDown(KeyCode.Space)){
            print("grond");
            if (movementType == MovementType.AddForce){
                //Force method
                rb.velocity = new Vector3(rb.velocity.x,0,rb.velocity.z);
                rb.AddForce(Vector3.up * jumpHeight);
            }
            if (movementType == MovementType.SetVelocity){
                //Set velocity method
                rb.velocity = new Vector3(rb.velocity.x,jumpHeight,rb.velocity.z);
            }
            }
        }
    }

    void FixedUpdate()
    {
        if (movementType == MovementType.AddForce){
        //Force method
        rb.AddForce(transform.forward * input.y * speed, ForceMode.Force);
        rb.AddForce(transform.right * input.x * speed, ForceMode.Force);
        }
        if (movementType == MovementType.SetVelocity){
        //Set velocity method
        rb.velocity = new Vector3 (0,rb.velocity.y,0);
        rb.velocity += transform.forward * input.y * speed;
        rb.velocity += transform.right * input.x * speed;
        }
    }

    void Look(){
        transform.eulerAngles += new Vector3(0,Input.GetAxisRaw("Mouse X"),0);

        cameraTransform.eulerAngles -= new Vector3(Input.GetAxisRaw("Mouse Y"),0,0);
    }
}
