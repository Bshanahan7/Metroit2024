using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private GameObject playerVisual;
    private Animator playerAnim;
    
    private void Awake()
    {
        playerAnim = playerVisual.GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
            playerAnim.SetBool("isShooting", true);
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            playerAnim.SetBool("isShooting", false);
        }
    } 

    private void Shoot()
    {
        Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
    }
}
