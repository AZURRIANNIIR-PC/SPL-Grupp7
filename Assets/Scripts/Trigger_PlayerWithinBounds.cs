using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_PlayerWithinBounds : MonoBehaviour {
    public GameObject crow;
    private Enemy_Pathfinder enemyPathfinder;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource audioSLow;
    [SerializeField] private AudioClip clip;

    private void Start() {
        enemyPathfinder = crow.GetComponent<Enemy_Pathfinder>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (enemyPathfinder.GetAliveStatus() == true) {
                enemyPathfinder.GetPlayerCloseBy(true); //Anropa å sätt variabeln isPlayerClose till true
                audioS.pitch = Random.Range(0.8f, 1f);
                audioS.PlayOneShot(clip);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (enemyPathfinder.GetAliveStatus() == true) {
                enemyPathfinder.GetPlayerCloseBy(false);
                audioSLow.pitch = Random.Range(0.8f, 1f);
                audioSLow.PlayOneShot(clip);
            }
        }
    }
}
