using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody rb;
    private float HorizontalInput;
    private float jumpforce = 5f;
    [SerializeField] private LayerMask groundedmask;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position+forwardMove+horizontalMove);
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
       
    }

    void jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isgrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2)+0.1f,groundedmask);
        
        rb.AddForce(Vector3.up*jumpforce);
    }
}//class
