using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitharaCloseUp : MonoBehaviour
{
    GameObject kitharaCloseUp;
    [SerializeField] private AudioSource string1;
    [SerializeField] private AudioClip note1;


    // Start is called before the first frame update
    void Start()
    {
        kitharaCloseUp = GameObject.FindWithTag("KitharaCloseUp");
        string1.clip = note1;
    }

    public void PlayString1()
    {
        string1.Play();
    }
}
