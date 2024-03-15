using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private Vector3 playerPosition;
    private const string PlayerPositionKey = "PlayerPosition";

    public void SavePosition(Vector3 position) {
        playerPosition = position;
        PlayerPrefs.SetFloat(PlayerPositionKey + "_x", playerPosition.x);
        PlayerPrefs.SetFloat(PlayerPositionKey + "_y", playerPosition.y);
        PlayerPrefs.SetFloat(PlayerPositionKey + "_z", playerPosition.z);
        PlayerPrefs.Save();
        Debug.Log("Saved player position: " + playerPosition);
    }

    public Vector3 GetPosition() {
        float savedX = PlayerPrefs.GetFloat(PlayerPositionKey + "_x", 0.0f);
        float savedY = PlayerPrefs.GetFloat(PlayerPositionKey + "_y", 0.0f);
        float savedZ = PlayerPrefs.GetFloat(PlayerPositionKey + "_z", 0.0f);

        return new Vector3(savedX, savedY, savedZ);
    }
}
