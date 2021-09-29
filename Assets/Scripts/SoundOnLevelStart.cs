using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnLevelStart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundToPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = soundToPlay;
        audioSource.Play();
    }
}
