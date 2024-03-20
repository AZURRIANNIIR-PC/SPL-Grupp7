//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marriage_Controller : MonoBehaviour {
    [SerializeField] private Transform playerNewPosition;
    [SerializeField] private Transform playerEndPosition;
    [SerializeField] private Transform brideStartPosition;
    [SerializeField] private Transform brideEndPosition;
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private GameObject marriageZone;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform brideTransform;
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private GameObject textParent;
    [SerializeField] private Text priestTextBubble; 
    [SerializeField] private string[] priestText; // Array med conversations-fraser
    [SerializeField] private float delayBetweenTexts = 3;
    private int currentTextIndex = 0;

    private void Start() {
        textParent.SetActive(false); //Gör texten osynlig
        brideTransform.position = brideStartPosition.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) { //När spelaren kommer inom collidern
        if (collision.CompareTag("Player") == true) {
            Debug.Log("Marriagezone entered");

            playerTransform.position = playerNewPosition.position; //Flyttar spelaren till rätt plats
            playerMovement.enabled = false;

            //Kollar om spelaren rör sig in
            if (Input.GetAxisRaw("Horizontal") != 0) {
                // Om spelaren håller ner höger pil så stanna den
                playerMovement.rb.velocity = new Vector2(0f, playerMovement.rb.velocity.y);
            }

            PlayAudio();
            StartCoroutine(Vows()); //Börja konversationen
        }
    }

    private void PlayAudio() {
        // Stop all currently playing AudioSources
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources) {
            source.Stop();
        }
        audioSource.PlayOneShot(audioClip);
    }

    IEnumerator Vows() {
        textParent.SetActive(true); //Gör texten synlig
        for (int i = 0; i < priestText.Length; i++) { //Itererar över strängarna i arrayen 
            priestTextBubble.text = priestText[i]; // current text sätts 
            yield return new WaitForSeconds(delayBetweenTexts); // Väntar på delay
        }
        EndScene();
    }

    private void EndScene() {
        StartCoroutine(MoveObjects());
    }

    IEnumerator MoveObjects() { //Flyttar spelaren och bruden till sin nya position åt höger
        float step = moveSpeed * Time.deltaTime;
        while (Vector3.Distance(playerTransform.position, playerEndPosition.position) > 0.1f ||
               Vector3.Distance(brideTransform.position, brideEndPosition.position) > 0.1f) {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, playerEndPosition.position, step);
            brideTransform.position = Vector3.MoveTowards(brideTransform.position, brideEndPosition.position, step);
            yield return null;
        }
        // Optional: implementera fadeout och main menu
    }
}
