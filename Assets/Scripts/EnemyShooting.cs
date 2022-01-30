using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float speed = 2f;
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
        float angle = 0; 
        float increment = 2 * (float)Math.PI / numberOfBullets;
        for(int i = 0; i < numberOfBullets; i++){
             angle += increment;

            Rigidbody2D rb = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            rb.velocity = new Vector2(speed * (float)Math.Cos(angle), speed * (float)Math.Sin(angle));
        }
    }
}
