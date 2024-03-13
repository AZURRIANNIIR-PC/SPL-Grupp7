using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marriage_Controller : MonoBehaviour {
    [SerializeField] private Vector2 groomPosition;
    [SerializeField] private Player_Movement playerMovement;
    
    void Start() {
        
    }

    
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {

        }
    }
}
