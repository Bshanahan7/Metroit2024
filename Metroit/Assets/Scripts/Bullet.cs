using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Player playerScript;
    [SerializeField] private GameObject player;
    [SerializeField] private bool facingRight;

    private void Awake()
    {
        playerScript = player.GetComponent<Player>();
    }
    private void Update()
    {
        facingRight = playerScript.facingRight;

        if(playerScript.FacingRight() == true)
        {
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        }
        if(playerScript.FacingRight() == false)
        {
            transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
