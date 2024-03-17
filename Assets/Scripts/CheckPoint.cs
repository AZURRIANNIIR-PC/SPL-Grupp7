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

            //spara namnet p� restartPositionen
            SaveGame.SaveRespawnPosition(gameObject.name);
            Debug.Log(name + "is saved");

            gameObject.GetComponent<SpriteRenderer>().sprite = checkPointUnlocked;
            Debug.Log("Checkpoint taken");
        }
    }
}
