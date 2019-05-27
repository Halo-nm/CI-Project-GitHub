using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip[] musicOptions;

    private List<int> musicChoices = new List<int>();

    AudioSource musicAudioSource;
    AudioSource soundFXAudioSource;

    AudioSource[] allAudioSources;

    void Start()
    {
        allAudioSources = GetComponents<AudioSource>();
        musicAudioSource = allAudioSources[0]; //the first spot in the audio source array is for music
        soundFXAudioSource = allAudioSources[1]; //the second spot is for sound effects

        /*if (!musicAudioSource.playOnAwake)
        {

        }*/
    }

    void Update()
    {
        if (!musicAudioSource.isPlaying)
        {
            int randomSongChoice = Random.Range(0, musicOptions.Length);
            for (int i = 0; i < musicOptions.Length; i++)
            {
                if (CheckMusicChosen(randomSongChoice))
                {
                    musicChoices.Add(randomSongChoice);
                    PlayMusicAudio(musicOptions[randomSongChoice]);
                }
                else if (musicOptions.Length == musicChoices.Count)
                {
                    musicChoices.Clear();
                }
            }
        }
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

    private bool CheckMusicChosen(int chosenNum)
    {
        for (int i = 0; i < musicChoices.Count; i++)
        {
            if (musicChoices[i] == chosenNum)
            {
                return false;
            }
        }
        return true;
    }

    public AudioClip GetDeathSound()
    {
        return deathSound;
    }
}
