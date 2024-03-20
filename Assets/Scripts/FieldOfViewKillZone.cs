//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewKillZone : MonoBehaviour
{
    public Respawn respawn;

    private void OnTriggerEnter(Collider collsion)
    {
        if(collsion.CompareTag("Player") == true)
        {
            Debug.Log("Player entered kill zone");
            respawn.PlayerRespawn();
        }
    }

}
