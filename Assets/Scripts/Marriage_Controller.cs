using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marriage_Controller : MonoBehaviour {
    [SerializeField] private Vector2 groomPosition;
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private GameObject marriageZone;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Text priestTextBubble; 
    [SerializeField] private string[] priestText; // Array med conversations-fraser
    [SerializeField] private float delayBetweenTexts = 3;
    private int currentTextIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision) { //När spelaren kommer inom collidern
        collision = marriageZone.GetComponent<BoxCollider2D>();

        if (collision.CompareTag("Player") == true) {
            //Stäng av spelarens kontroller (att kunna röra gubben)
            playerMovement.enabled = false;

            playerTransform.position = groomPosition; //Flyttar spelaren till rätt plats

            StartCoroutine(Vows()); //Börja konversationen
        }
    }

    IEnumerator Vows() {
        for (int i = 0; i < priestText.Length; i++) { //Itererar över strängarna i arrayen 
            priestTextBubble.text = priestText[i]; // current text sätts 

            yield return new WaitForSeconds(delayBetweenTexts); // Väntar på delay
        }
    }
}
