using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmful : MonoBehaviour
{
    public int damage = 2;

    //�hh pr�var o �ndra ngt h�r tjohej
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            //if (gameObject.GetComponent<EnemyMovement>().isHurt == false)
            //{
                collision.gameObject.GetComponent<PlayerState>().doHarm(damage);
                Debug.Log("player hurt");
            //}
        }
    }
}
