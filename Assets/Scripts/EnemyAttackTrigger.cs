using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private Animator animator;
    private AttackArea attackArea;
    private bool attacking = false;
    private float timeToAttack = 2f;
    private float timer = 0;

    private bool inAttackTrigger = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        attackArea = gameObject.GetComponentInChildren<AttackArea>();
        attackArea.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (inAttackTrigger == true) //&& timer >= timeToAttack
        {
            Attack();
            if (attacking == true)
            {
                timer += Time.deltaTime;
                if (timer >= timeToAttack)
                {
                    timer = 0;
                    attacking = false;
                    attackArea.gameObject.SetActive(attacking);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            inAttackTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            inAttackTrigger = false;
        }
    }

    private void Attack()
    {
        if(attacking == false)
        {
            attacking = true;
            animator.SetTrigger("DoAttack"); //sätter igång animationen - är en trigger, inte en bool etc
            Invoke("enableAttackArea", 0.3f);
        }
    }

    public void enableAttackArea()
    {
        attackArea.gameObject.SetActive(attacking);
        //enablear attack area efter en liten stund så det timear med att animation hinner tr�ffa fienden
    }
}
