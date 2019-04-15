using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] string levelToLoad = "";
    [SerializeField] bool selectRandomScene = false;

    string[] scenesList = new string[3] {"TestScene1", "TestScene2", "TestScene3" }; //string (array or list?) of levels to randomly select from

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (selectRandomScene)
        {
            int randomSceneNum = Random.Range(0, scenesList.Length); //randomly selects a number to use to select from the list
            //SceneManager.LoadScene(scenesList[randomSceneNum]);
            Debug.Log("Load " + scenesList[randomSceneNum]);
        }
        else if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}