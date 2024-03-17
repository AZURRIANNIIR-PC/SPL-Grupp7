using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private void Start()
    {
        // Load the saved respawn position
        string respawnName = SaveGame.LoadRespawnPosition();

        // Debug: Check if respawnName is correctly loaded
        Debug.Log("Loaded respawn name: " + respawnName);

        // Find GameObject by name and set it as the active respawn position
        GameObject respawnPosition = GameObject.Find(respawnName);
        if (respawnPosition != null)
        {
            PlayerState playerState = FindObjectOfType<PlayerState>();
            if (playerState != null)
            {
                playerState.ChangeRespawnPosition(respawnPosition);

                // Debug: Check if respawnPosition is found
                Debug.Log("Respawn position: " + respawnPosition);

                // Debug: Check if PlayerState component is found
                Debug.Log("PlayerState component: " + playerState);


            }
            else
            {
                Debug.LogError("PlayerState component not found!");
            }
        }
        else
        {
            Debug.LogWarning("Saved respawn position not found!");
        }
    }
}

