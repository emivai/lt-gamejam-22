using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int dmg = 1;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }

    }

    void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            if(enemy.GetComponent<Bullet>() != null){
                enemy.GetComponent<Bullet>().Damage(dmg);
            }else {
                enemy.GetComponent<Enemy>().Damage(dmg);
            }
            
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
