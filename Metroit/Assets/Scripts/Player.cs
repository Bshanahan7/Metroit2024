using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    private bool isOnGround = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //if(other.FindObjectWithTag("Floor"))
        //{
        //    isOnGround = true;
        //}

        //MAke this work plz thx find object with tag.
    }
}
