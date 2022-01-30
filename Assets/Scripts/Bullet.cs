using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int dmg = 1;

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
}
