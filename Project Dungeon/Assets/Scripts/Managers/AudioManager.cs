using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip deathSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip; //set the audio source clip
        audioSource.Play(); //the sound clip is played
    }

    public AudioClip GetDeathSound()
    {
        return deathSound;
    }
}
