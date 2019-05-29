using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiKeyLock : MonoBehaviour
{
    [SerializeField] List<GameObject> keysRequired = new List<GameObject>();
    [SerializeField] AudioClip soundToPlay;

    AudioManager audioManager;

    void Update()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (keysRequired.Count <= 0) //destroys this object if all required keys are retrieved
        {
            if (soundToPlay != null)
            {
                audioManager.PlaySoundFXAudio(soundToPlay);
            }
            Destroy(gameObject);
        }
    }

    public void UpdateKeysRequired(GameObject keyToRemove) //removes a specific key from the array
    {
        for (int i = 0; i < keysRequired.Count; i++)
        {
            if (keysRequired[i] == keyToRemove)
            {
                keysRequired.Remove(keyToRemove);
            }
        }
    }
}
