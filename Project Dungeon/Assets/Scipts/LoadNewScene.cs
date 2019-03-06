using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] string levelToLoad = "Inside_House";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}