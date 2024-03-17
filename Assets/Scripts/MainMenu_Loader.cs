using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Loader : MonoBehaviour {
    [SerializeField] private Player_Movement playerMovement;
    public SaveGame saveGame;

    private void OnTriggerEnter2D(Collider2D collision) { //När spelaren kommer till slutet av banan
        if(collision.CompareTag("Player") == true) {
            SceneManager.LoadScene(3);
            //playerMovement.SavePositionOnExit();
            //playerMovement.SetIsAtEnd(true);
            saveGame.DeleteSavedPlayerPosition();
        }
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
}
