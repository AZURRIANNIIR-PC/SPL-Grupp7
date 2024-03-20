//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_textbubble : MonoBehaviour {
    [SerializeField] private GameObject textparent;
    [SerializeField] private Text text;
    [SerializeField] private string conversationStarter;
    //[SerializeField] private string conversationEnder;
    //[SerializeField] private AudioSource audioS;
    //[SerializeField] private AudioClip clip;

    void Start() {
        textparent.SetActive(false); // Gör texten osynlig
        //textComponent.text = conversationStarter; //Sätt texten till urspungliga
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) { //Om spelaren integrerar
            textparent.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            textparent.SetActive(false);
        }
    }
}
