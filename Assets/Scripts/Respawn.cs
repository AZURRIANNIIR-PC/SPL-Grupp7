//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    // [SerializeField] private GameObject startPosition;

    [SerializeField] private GameObject respawnPosition;
    [SerializeField] private GameObject newRespawnPosition;
    private int amountToCollect = 1;

    public void PlayerRespawn() {
        if (GetComponent<PlayerState>().foodAmount >= amountToCollect) {
            NewRespawn();
        }
        Debug.Log("Respawning player");
        gameObject.transform.position = respawnPosition.transform.position;
    }

    void NewRespawn() {
        respawnPosition = newRespawnPosition;
    }
}
