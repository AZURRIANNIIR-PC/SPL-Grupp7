using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] private int health = 6;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        rb.isKinematic = true; //stänger av rigidBody
        GetComponent<BoxCollider2D>().enabled = false; //då faller gubben genom marken lol
        GetComponentInChildren<AttackArea>().enabled = false;
        //Invoke("DestroyGameObject", 1.3f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
