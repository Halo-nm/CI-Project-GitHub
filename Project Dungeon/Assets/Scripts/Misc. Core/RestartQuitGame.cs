using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartQuitGame : MonoBehaviour
{
    public void RestartGame()
    {
        System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe")); //new program
        Application.Quit(); //kill current process
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
