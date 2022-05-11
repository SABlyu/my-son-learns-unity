using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);
    }
}