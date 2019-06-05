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
    }

    void Update()
    {
        if (!musicAudioSource.isPlaying) //checks if the first audio source is playing
        {
            int randomSongChoice = Random.Range(0, musicOptions.Length);
            for (int i = 0; i < musicOptions.Length; i++) //randomly chooses a song //doesn't pick a duplicate until songs are run out of
            {
                if (CheckMusicChosen(randomSongChoice))
                {
                    musicChoices.Add(randomSongChoice);
                    PlayMusicAudio(musicOptions[randomSongChoice]);
                }
                else if (musicOptions.Length == musicChoices.Count)
                {
                    musicChoices.Clear(); //emptys the musisChoices list to allow duplicate songs to be picked again
                }
            }
        }
    }

    public void PlayMusicAudio(AudioClip audioClip) //plays music on the first audio source
    {
        allAudioSources[0].clip = audioClip; //set the audio source clip
        allAudioSources[0].Play(); //the sound clip is played
    }

    public void PlaySoundFXAudio(AudioClip audioClip) //play soundFX on the second audio source
    {
        allAudioSources[1].clip = audioClip; //set the audio source clip
        allAudioSources[1].Play(); //the sound clip is played
    }

    private bool CheckMusicChosen(int chosenNum) //checks the musicChoices list to see if that specific index/song was already chosen
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
