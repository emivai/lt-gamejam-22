using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float health = 1;
    public float elapsedTime = 0;
    public float maxRange = 10f;
    public Rigidbody2D rb;
    public int dmg = 1;

    void Update(){
        if(rb.velocity.magnitude * elapsedTime > maxRange){
            Destroy(gameObject);
        }

        elapsedTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.name == "Player"){
            Debug.Log("Bullet hit the player");

            Player player = hitInfo.GetComponent<Player>();

            if(player != null){
                player.TakeDamage(dmg);
            }

            Destroy(gameObject);
        }
    }

    public void Damage(int damage){
        health -= damage;

        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
