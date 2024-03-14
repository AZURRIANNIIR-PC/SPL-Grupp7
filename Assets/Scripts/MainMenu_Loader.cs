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
}
