using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShooting : MonoBehaviour
{
    public float speed = 5f;
    public float shootCooldown = 0;
    public Transform firePoint;
    public Rigidbody2D bulletPrefab;
    public float numberOfBullets = 4; 

    // Update is called once per frame
    void Update()
    {
        if(shootCooldown > 1f){
            Shoot();

            shootCooldown = 0;
        }

        shootCooldown += Time.deltaTime;
    }

    void Shoot(){
        var playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        var bulletRB = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletRB.velocity = (playerRB.position - bulletRB.position).normalized * speed;
    }
}
