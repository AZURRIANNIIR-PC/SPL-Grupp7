//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}