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
            EnemyState health = collider.GetComponent<EnemyState>();
            health.Damage(damage);
            Debug.Log("Enemy is hurt!");
        }
    }
}
