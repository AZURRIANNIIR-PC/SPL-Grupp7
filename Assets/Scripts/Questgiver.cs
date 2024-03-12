using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questgiver : MonoBehaviour {
    [SerializeField] private GameObject textparent;
    [SerializeField] private Text text;
    [SerializeField] private string questBeginText;
    [SerializeField] private string questCompleteText;
    [SerializeField] private GameObject doorToOpenWhenQuestIsComplete;
    //[SerializeField] private AudioSource audioS;
    //[SerializeField] private AudioClip clip;
    private bool questCompleted = false;

    void Start() {
        textparent.SetActive(false); // Gör texten osynlig
        text.text = questBeginText; //Sätt texten till urspungliga
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) { //Om spelaren integrerar
            if (questCompleted) {
                text.text = questCompleteText;
                Debug.Log("uppdraget slutfört");
                //doorToOpenWhenQuestIsComplete.SetActive(false);
            }
        } else {
            text.text = questBeginText;
            Debug.Log("text synlig");
        }
        textparent.SetActive(true);
        //audioS.PlayOneShot(clip);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            textparent.SetActive(false);
            Debug.Log("text försvinner");
        }
    }
}
