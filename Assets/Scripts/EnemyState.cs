using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] private int health = 6;
    private Animator animator;
    private Rigidbody2D rb;
    EnemyHarmful harmfulScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        harmfulScript = GetComponent<EnemyHarmful>();
        harmfulScript.enabled = true;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy is dead!");
        animator.SetBool("IsDead", true);
        rb.isKinematic = true; //stänger av rigidBody, annars kommer fienden falla genom världen när dens collider tas bort
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<EnemyAttackTrigger>().enabled = false;
        //GetComponentInChildren<AttackArea>().enabled = false;
        harmfulScript.enabled = false; //av ngn anledning funkar den här inte? man blir skadad ändå ifall man går in i fienden
        Invoke("DestroyGameObject", 1f);

        //PlayerPrefs.SetInt("isDead", 1); //ifall död = 1, ifall levande = 0
    }

    private void DestroyGameObject() //om man vill att fiendens lik ska försvinna, ej ligga kvar
    {
        Destroy(gameObject);
    }
}
