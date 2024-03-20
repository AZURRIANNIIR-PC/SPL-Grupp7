//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Sprite checkPointUnlocked;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = checkPointUnlocked;
        }
    }
}
