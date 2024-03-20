using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    public const string Scene2RestartPositions = "RestartPosition2,RestartPosition3,RestartPosition4";
    [SerializeField] private SaveGame saveGame;

    //private void Start() {
    //    string savedRespawnPosition = SaveGame.LoadRespawnPosition();

    //    if (Scene2RestartPositions.Contains(savedRespawnPosition)) { //Omd en inte har checkpoints sparade från lvl 2
    //        Debug.Log("savedRespawnPosition is" + savedRespawnPosition);
    //        SceneManager.LoadScene(2);
    //        Debug.Log("Entered changeLevel to Scene 2");
    //    } else {
    //        SceneManager.LoadScene(1);
    //    }
    //}

    public void LoadCorrectLevel() {
        //string savedRespawnPosition = SaveGame.LoadRespawnPosition();
        string savedRespawnPosition = saveGame.GetKey();

        if (Scene2RestartPositions.Contains(savedRespawnPosition)) { //Omd en inte har checkpoints sparade från lvl 2
            //Debug.Log("savedRespawnPosition is" + savedRespawnPosition);
            SceneManager.LoadScene(2);
            Debug.Log("Loaded lvl 2");
        } else {
            Debug.Log("Loaded lvl 1");
            SceneManager.LoadScene(1);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            SceneManager.LoadScene(2);
            Debug.Log("Entered changeLevel");
        }
    }
}
    

