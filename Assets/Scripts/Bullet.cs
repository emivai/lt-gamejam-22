using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int dmg = 1;
    public float extraArea = 10f;

    void Update(){
        /*
         * TODO: Fix this fucking shit
         */
        if(Camera.main.transform.position.x + extraArea - gameObject.transform.position.x < 0 &&
           Camera.main.transform.position.y + extraArea - gameObject.transform.position.y < 0){
               Destroy(gameObject);
           }

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
}
