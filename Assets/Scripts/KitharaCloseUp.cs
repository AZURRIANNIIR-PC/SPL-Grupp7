using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitharaCloseUp : MonoBehaviour
{
    GameObject kitharaCloseUp;
    [SerializeField] private AudioSource string1;
    [SerializeField] private AudioClip note1;
    private Player_Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        kitharaCloseUp = GameObject.FindWithTag("KitharaCloseUp");
        string1.clip = note1;
    }

    // Update is called once per frame
    void Update()
    {
        //if(kitharaCloseUp.activeSelf == true)
        //{
        //    playerMovement.enabled = false;
        //} else if (kitharaCloseUp.activeSelf == false)
        //{
        //    playerMovement.enabled = true;
        //}
    }

    public void PlayString1()
    {
        string1.Play();
    }
}
