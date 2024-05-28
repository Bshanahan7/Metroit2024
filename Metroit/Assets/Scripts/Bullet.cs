using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime); 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if()  what
       // {
       //     Destroy(gameObject);
       // }
    }
}
