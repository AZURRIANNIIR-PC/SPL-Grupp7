using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour {
    [SerializeField] private Player_Movement playerMovement;

    public void StartGame() {
        playerMovement.enabled = true;
        SceneManager.LoadScene(1);

        playerMovement.SetIsAtEnd(true);
    }
}
