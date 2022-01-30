using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     * Arbitraty number of health points
     */ 
    public int health = 3;

    public void TakeDamage(int dmg){
        health -= dmg;

        if(health <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("The player died");
        Destroy(gameObject);
    }
}
