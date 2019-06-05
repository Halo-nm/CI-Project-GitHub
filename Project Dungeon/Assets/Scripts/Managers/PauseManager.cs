using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public static bool gamePaused; //public so it's accessible, but static so this script can't be specifically referenced but can check if the bool is active

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; //base value of time motion
    }

    public void PauseGame()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; //"freezes time"
    }
}
