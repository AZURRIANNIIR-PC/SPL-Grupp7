//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

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
    // public PickUpFood pickUpFood;
    private bool questCompleted = false;
    private int amountToCollect = 1;

    void Start() {
        textparent.SetActive(false); // Gör texten osynlig
        text.text = questBeginText; //Sätt texten till urspungliga
    }



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) { //Om spelaren integrerar

            if (collision.GetComponent<PlayerState>().foodAmount >= amountToCollect) {
                questCompleted = true;
                Debug.Log("quest complete now true");
            }
            if (questCompleted) {
                Debug.Log("uppdraget slutfört");
                text.text = questCompleteText;

                //doorToOpenWhenQuestIsComplete.SetActive(false);
            }
        }
        else {
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
