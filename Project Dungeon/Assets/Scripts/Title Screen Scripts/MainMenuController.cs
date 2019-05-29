using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //used to access buttons
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] string levelToLoad = "Level1";
    [SerializeField] bool chooseSpecificLevel = true;

    public void PlayGame()
    {
        if (chooseSpecificLevel)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ExitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
