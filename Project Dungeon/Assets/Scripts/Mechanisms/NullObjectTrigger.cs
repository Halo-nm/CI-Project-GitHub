using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullObjectTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToCheck;
    [SerializeField] AudioClip soundToPlay;

    AudioManager audioManager;

    void Update()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (CheckObjects()) //checks to make sure all the objects are null //if they are, then destroy the object the script is attached to
        {
            if (soundToPlay != null)
            {
                audioManager.PlaySoundFXAudio(soundToPlay);
            }
            Destroy(gameObject);
        }
    }

    private bool CheckObjects()
    {
        for (int i = 0; i < objectsToCheck.Length; i++)
        {
            if (objectsToCheck[i] != null) //if any of the objects are still alive, return false
            {
                return false;
            }
        }
        return true;
    }
}
