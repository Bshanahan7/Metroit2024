using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb;
    private Animator playerAnim;

    [Header("GameObjects")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gunPoint;
    [SerializeField] private GameObject playerVisual;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpStartTime;
    private float jumpTime;
    
    [Header("Helpful booleans")]
    [SerializeField] private bool isJumping;
    [SerializeField] private bool inTheAir;
    [SerializeField] private bool isMoving;
    public bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim  = playerVisual.GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        HandleMovement();
        HandleJumping();
    }
    private void Update()
    {
        HandleGun();
        HandleAnimations();
    }
    
    private void HandleMovement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            transform.Translate(Vector2.right * speed);
            playerAnim.SetBool("isMoving", true); 
        }
        if(Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            transform.Translate(Vector2.left * speed);
            playerAnim.SetBool("isMoving", true);
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
    
    private void HandleAnimations()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
        }
        if(isMoving == false)
        {
            playerAnim.SetBool("isMoving", false);
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
            Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
        }
    }
    public bool FacingRight()
    {
        facingRight = true;
        return facingRight;
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