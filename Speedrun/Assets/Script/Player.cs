using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    { 
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(20,20,20);
        }
    }
}
