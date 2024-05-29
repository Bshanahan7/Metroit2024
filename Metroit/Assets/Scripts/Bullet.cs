using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Player playerScript;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        playerScript = player.GetComponent<Player>();
    }
    private void Update()
    {
        if(playerScript.facingRight == true)
        {
            transform.Translate(transform.right * bulletSpeed * Time.deltaTime); 
        }
        if(playerScript.facingRight == false)
        {
            transform.Translate(-transform.right * bulletSpeed * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
