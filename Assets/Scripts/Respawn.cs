using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
   // [SerializeField] private GameObject startPosition;
    public GameObject respawnPosition;

    public void PlayerRespawn()
    {
        Debug.Log("Respawning player");
        gameObject.transform.position = respawnPosition.transform.position;
    }
}
