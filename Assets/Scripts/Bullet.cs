using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int dmg = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(speed, 0);
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
