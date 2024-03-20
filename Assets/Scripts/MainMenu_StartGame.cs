//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MainMenu_StartGame : MonoBehaviour {
//    public void StartGame() {
//        SceneManager.LoadScene(1);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StartGame : MonoBehaviour
{
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private NextLevel nextLevel;

    private void StartGame()
    {
        playerMovement.enabled = true;
        nextLevel.LoadCorrectLevel();
    }
}