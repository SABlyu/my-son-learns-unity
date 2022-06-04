using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;
    public float RunSpeed = 15;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public Transform lastSafePoint;

    public Respawn respawn;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = RunSpeed;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10f;
        }

        velocity.y += gravity * Time.deltaTime; // velocity.y = velocity.y + grav...

        controller.Move(velocity * Time.deltaTime);

        if (lastSafePoint != null)
        {
            //this.GetComponent<Transform>().position = lastSafePoint.position;
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        lastSafePoint = collider.GetComponent<Transform>();
    }
}