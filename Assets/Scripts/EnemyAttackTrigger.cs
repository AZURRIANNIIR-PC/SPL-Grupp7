using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private Animator animator;
    private AttackArea attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.7f;
    private float timer = 0;

    private bool inAttackTrigger = false;
    private float colliderInactiveTime; //hur länge attackArea collidern har varit inaktiv, aka hur länge det gått sedan senaste attacken

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
            // Kontrollera om det har gått minst [1.5] sekund sedan collidern sattes inaktiv - hur lång tid det ska ta mellan attacker
            //ps denna siffra kan ändras till en public float, så att olika fiender kan ha olika difficulty
            if (GetTimeSinceColliderInactive() >= 1.5f)
            {
                Attack();
                if (attacking == true) //ifall fienden nu attackerar
                {
                    timer += Time.deltaTime; //öka timern med Time.deltatime (tiden som gått sen senaste framen)
                    if (timer >= timeToAttack) //ifall timern når tiden för hur lång tid det tar att attackera - nollställ allt, sluta attackera
                    {
                        timer = 0;
                        attacking = false;
                        attackArea.gameObject.SetActive(false);
                        SetColliderInactive(); //startar timern för hur lång tid det gått sedan attackArea sattes inaktiv
                    }

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
            Invoke("EnableAttackArea", 0.3f);
        }
    }

    public void EnableAttackArea()
    {
        attackArea.gameObject.SetActive(attacking);
        //enablear attack area efter en liten stund så det timear med att animation hinner tr�ffa fienden
    }

    private void SetColliderInactive() //startar timern för när attackArea sattes inaktiv
    {
        colliderInactiveTime = Time.time;
    }

    private float GetTimeSinceColliderInactive() //räknar hur lång tid det gått sedan attackArea sattes inaktiv
    {
        return Time.time - colliderInactiveTime;
    }
}
