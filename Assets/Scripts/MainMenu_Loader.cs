//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Loader : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") == true) {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
