using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectDestroyer : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToDestroyList; //list of general objects to destroy on activation
    [SerializeField] GameObject[] multipleDestroyList; //list of objects that all get destroyed on a single activation
    [SerializeField] bool destroyMultipleAtOnce = true;
    [SerializeField] AudioClip soundToPlay;

    AudioManager audioManager;

    void Start()
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
            if (destroyMultipleAtOnce)
            {
                bool objectFound = false;
                while (!objectFound)
                {
                    int randomObjectNum = Random.Range(0, objectsToDestroyList.Length + 1);

                    if (objectsToDestroyList.Length > randomObjectNum)
                    {
                        if (objectsToDestroyList[randomObjectNum] != null)
                        {
                            objectFound = true;
                            Destroy(objectsToDestroyList[randomObjectNum]);
                        }
                    }
                    else if (CheckMultipleDestroyList())
                    {
                        objectFound = true;
                        for (int i = 0; i < multipleDestroyList.Length; i++)
                        {
                            Destroy(multipleDestroyList[i]);
                        }
                    }
                }
            }
            else
            {
                bool objectFound = false;
                while (!objectFound)
                {
                    int randomObjectNum = Random.Range(0, objectsToDestroyList.Length);

                    if (objectsToDestroyList[randomObjectNum] != null)
                    {
                        objectFound = true;
                        Destroy(objectsToDestroyList[randomObjectNum]);
                    }
                }
            }
            Destroy(gameObject);
        }
    }

    private bool CheckMultipleDestroyList()
    {
        if (multipleDestroyList[0] != null)
        {
            return true;
        }
        return false;
    }
}
