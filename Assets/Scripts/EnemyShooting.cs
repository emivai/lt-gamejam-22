using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float shootCooldown = 0;
    public Transform firePoint;
    public GameObject bulletPrefab;
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
        for(int i = 0; i < 2; i++){
            // bulletPrefab.GetComponent<Bullet>().velocity = new Vector2(3f, 2f);

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
