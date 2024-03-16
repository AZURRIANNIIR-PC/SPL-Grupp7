using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private Vector3 playerPosition;
    private const string PlayerPositionKey = "PlayerPosition";
    [SerializeField] private GameObject player;
    private bool isPlayerInsideTrigger = false;
    private float saveTimer = 0f;
    private float saveInterval = 2f;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player") == true) {
            isPlayerInsideTrigger = true;
            Debug.Log("Player is within trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            isPlayerInsideTrigger = false;
            Debug.Log("Player left trigger");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) { //Uppdatera m intervall medan spelaren är i triggern
        if (collision.CompareTag("Player") == true && isPlayerInsideTrigger) {
            saveTimer += Time.deltaTime;
            if (saveTimer >= saveInterval) {
                SavePosition();
                saveTimer = 0f;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision) { // Spara bara spelarens position om hen är innanför collidern
    //    if (collision.CompareTag("Player") == true) { //Kolla om spelaren kolliderar
    //        Debug.Log("Player is within trigger");
    //        if (collision.isTrigger) { //Kollar om det är en trigger collider
    //            SavePosition();
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision) {
    //    if (collision.CompareTag("Player") == true) {  // Check if player is leaving {
    //        SavePosition();
    //    }
    //}

    public Vector3 GetPosition() {
        if (playerPosition.x !> 330) { //Om spelaren inte är utanför triggern
            float savedX = PlayerPrefs.GetFloat(PlayerPositionKey + "_x", 0.0f);
            float savedY = PlayerPrefs.GetFloat(PlayerPositionKey + "_y", 0.0f);
            float savedZ = PlayerPrefs.GetFloat(PlayerPositionKey + "_z", 0.0f);

            return new Vector3(savedX, savedY, savedZ); //Returnera var hen är
        } else {
            return new Vector3(225, 0, 0); //Annars returnera max position åt höger
        }
        
    }

    private void SavePosition() {
        if (isPlayerInsideTrigger) {
            playerPosition = player.transform.position;
            PlayerPrefs.SetFloat(PlayerPositionKey + "_x", playerPosition.x);
            PlayerPrefs.SetFloat(PlayerPositionKey + "_y", playerPosition.y);
            PlayerPrefs.SetFloat(PlayerPositionKey + "_z", playerPosition.z);
            PlayerPrefs.Save();
            Debug.Log("Saved player position: " + playerPosition);
        }
    }
}



//private void SavePosition(Vector3 position) {
//    playerPosition = position;
//    PlayerPrefs.SetFloat(PlayerPositionKey + "_x", playerPosition.x);
//    PlayerPrefs.SetFloat(PlayerPositionKey + "_y", playerPosition.y);
//    PlayerPrefs.SetFloat(PlayerPositionKey + "_z", playerPosition.z);
//    PlayerPrefs.Save();
//    Debug.Log("Saved player position: " + playerPosition);
//}