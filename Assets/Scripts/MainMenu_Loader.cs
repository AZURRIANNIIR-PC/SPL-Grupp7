using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Loader : MonoBehaviour {
    [SerializeField] private Player_Movement playerMovement;
    public SaveGame saveGame;
    [SerializeField] private GameObject respawnOG;

    private void OnTriggerEnter2D(Collider2D collision) { //När spelaren kommer till slutet av banan
        if(collision.CompareTag("Player") == true) {
            saveGame.DeleteSavedPlayerPosition(); //Raderar spelarens position och sparade checkpoints på level 2
            //Debug.Log("savedRespawnPosition is" + savedRespawnPosition); //Borde vara tom efter att man kommit till slutet
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(respawnOG); //Sätter respawn till början
            //spara namnet p� restartPositionen
            SaveGame.SaveRespawnPosition(respawnOG.name);
            //Debug.Log(name + "is saved");

            playerMovement.enabled = true;

            SceneManager.LoadScene(3); //Laddar credit scene
            //playerMovement.SavePositionOnExit();
            //playerMovement.SetIsAtEnd(true);
            //saveGame.DeleteSavedPlayerPosition(); //För säkerhets skull raderas de igen
        }
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
}
