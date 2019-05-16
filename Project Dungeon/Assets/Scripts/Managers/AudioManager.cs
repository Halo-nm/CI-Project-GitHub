using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip deathSound;

    AudioSource musicAudioSource;
    AudioSource soundFXAudioSource;

    AudioSource[] allAudioSources;

    void Start()
    {
        allAudioSources = GetComponents<AudioSource>();
        musicAudioSource = allAudioSources[0]; //the first spot in the audio source array is for music
        soundFXAudioSource = allAudioSources[1]; //the second spot is for sound effects
    }

    public void PlayMusicAudio(AudioClip audioClip)
    {
        allAudioSources[0].clip = audioClip; //set the audio source clip
        allAudioSources[0].Play(); //the sound clip is played
    }

    public void PlaySoundFXAudio(AudioClip audioClip)
    {
        allAudioSources[1].clip = audioClip; //set the audio source clip
        allAudioSources[1].Play(); //the sound clip is played
    }

    public AudioClip GetDeathSound()
    {
        return deathSound;
    }
}
