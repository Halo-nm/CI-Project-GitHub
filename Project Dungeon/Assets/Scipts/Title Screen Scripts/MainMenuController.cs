using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //used to access buttons
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] string levelToLoad = ""; //Nathan made this addition
    [SerializeField] Button startButton; //Nathan made this addition

    public void Start()
    {
        startButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(levelToLoad); //Nathan made this change. Seeing if there is a difference
    }

    public void ExitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
