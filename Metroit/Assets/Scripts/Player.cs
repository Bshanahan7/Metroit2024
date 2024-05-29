using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb;

    [Header("GameObjects")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gunPoint;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpStartTime;
    private float jumpTime;
    
    [Header("Helpful booleans")]
    [SerializeField] private bool isJumping;
    [SerializeField] private bool inTheAir;
    public bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {
        HandleMovement();
        HandleJumping();
        HandleGun();
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
        if(Input.GetKeyDown(KeyCode.A) && facingRight == true)
        {
            FlipPlayer();
        }
        if(Input.GetKeyDown(KeyCode.D) && facingRight == false)
        {
            FlipPlayer();
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
        if(Input.GetKeyDown(KeyCode.E) && facingRight)
        {
            Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            inTheAir = false;
        }
    }
    private void FlipPlayer()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
