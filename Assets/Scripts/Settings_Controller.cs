using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings_Controller : MonoBehaviour {
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Player_Movement playerMovement;
    private bool settingsOpen = false;

    private void Start() {
        settingsPanel.SetActive(false); //Se till att settingsPanel är osynlig
    }

    public void ClickController() {
        if (settingsOpen) { //Om panelen är öppen
            CloseSetting();
        } else {
            OpenSettings();
        }
    }

    public void OpenSettings() {
        Debug.Log("opens settings");
        Time.timeScale = 0f; //Pausar spelet

        settingsPanel.SetActive(true); //Gör settingsPanel synlig

        //Stäng av spelarens kontroller (att kunna röra gubben)
        playerMovement.enabled = false; 
    }

    public void CloseSetting() {
        Time.timeScale = 1f; //Pausa upp spelet
        settingsPanel.SetActive(false);//Gör settingsPanel osynlig

        //Aktivera spelarens kontroller:
        playerMovement.enabled = true; 
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
