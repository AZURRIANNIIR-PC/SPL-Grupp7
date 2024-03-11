using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyState>() != null)
        {
            EnemyState enemyHealth = collider.GetComponent<EnemyState>();
            enemyHealth.Damage(damage);
            Debug.Log("Enemy is hurt!");
        } else if (collider.CompareTag("Player") == true)
        {
            PlayerState playerHealth = collider.GetComponent<PlayerState>();
            playerHealth.doHarm(2);
        }
    }
}
