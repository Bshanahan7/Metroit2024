using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPoint;
    private Rigidbody2D rb;
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    } 
    private void Shoot()
    {
        Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
    }
}
