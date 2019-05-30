using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject objectToChange;
    [SerializeField] bool destroyObject = true; //consider for spawning walls
    [SerializeField] AudioClip soundToPlay;

    AudioManager audioManager;

    void Update()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (soundToPlay != null)
            {
                audioManager.PlaySoundFXAudio(soundToPlay);
            }
            if (destroyObject)
            {
                Destroy(objectToChange);
            }
            else
            {
                //Instantiate(objectToChange, asdf, asdf); //consider for spawning walls
            }
        }
    }
}
