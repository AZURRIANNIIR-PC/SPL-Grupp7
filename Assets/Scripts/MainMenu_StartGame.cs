using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour {
    [SerializeField] private GameObject gameObject;

    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
