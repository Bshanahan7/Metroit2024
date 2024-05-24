using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    private Rigidbody2D rb;
    [Header("Stuff")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool inTheAir;
    [SerializeField] private float jumpStartTime;
    [SerializeField] private bool isJumping;
    private float jumpTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {
        HandleMovement();
        HandleJumping();
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
    }

    private void HandleJumping()
    {
        if(Input.GetKey(KeyCode.Space) && !inTheAir)
        {
            jumpTime = jumpStartTime;
            rb.velocity = Vector2.up * jumpForce;
            inTheAir = true;
            isJumping = true;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTime > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void HandleGun()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //DO THIS :D
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            inTheAir = false;
        }
    }
}
