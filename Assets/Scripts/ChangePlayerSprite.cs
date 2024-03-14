using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine.Animations;
using UnityEngine;

public class ChangePlayerSprite : MonoBehaviour
{
    [SerializeField] private Sprite grownUpSprite;
    [SerializeField] private AnimatorController grownUpAnimatorController;
    private Animator animator;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            player.GetComponent<SpriteRenderer>().sprite = grownUpSprite;
            animator = player.GetComponent<Animator>();
            animator.runtimeAnimatorController = grownUpAnimatorController;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            //g�ra s� collidern blir "h�rd", s� spelaren ej kan g� tbx?
        }
    }
}
