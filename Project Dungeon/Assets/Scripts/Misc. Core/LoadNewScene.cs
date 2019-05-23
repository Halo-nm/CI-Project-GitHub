
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] string levelToLoad = "";
    [SerializeField] bool selectRandomScene = true;
    [SerializeField] bool fillPlayerHealth = true;
    [SerializeField] float swapLevelTime = 2f;

    private int storeLevelToLoad;
    private int scenesListLength;
    private int chosenScenesListLength;

    PlayerHealthManager playerHealthManager;
    CharacterSelector characterSelector;
    AudioManager audioManager;
    PlayerStartPoint playerStartPoint;
    LevelTransitionManager levelTransitionManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerStartPoint = FindObjectOfType<PlayerStartPoint>();
        levelTransitionManager = FindObjectOfType<LevelTransitionManager>();
    }

    void Update()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();

        if (characterSelector != null) //checks if characterSelector is active/not destroyed
        {
            if (characterSelector.GetCharacterActive()) //checks if the character is active
            {
                playerHealthManager = characterSelector.GetCharacterObject().GetComponent<PlayerHealthManager>(); //gets the current player instance's health manager
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //checks if the player was the object that collided with the gameobject the script is attached to
        {
            characterSelector.StartHidePlayerTimer();
            StartCoroutine(SwapLevelTimer());
        }
    }

    IEnumerator SwapLevelTimer()
    {

        characterSelector.GetCharacterObject().SetActive(false);

        yield return new WaitForSeconds(swapLevelTime);

        if (selectRandomScene) //if the selectRandomScene boolean is active, then the gameobject the script is attached to wants to randomly load levels from a list
        {
            int scenesListLength = levelTransitionManager.GetScenesList().Count;
            int chosenScenesListLength = levelTransitionManager.GetChosenScenesList().Count;

            if (scenesListLength > 0 && (scenesListLength != chosenScenesListLength)) //if the array doesn't have any levels to select from, the code will not be run to avoid any errors
            {
                int randomSceneNum;
                bool available = false;
                while (!available) //if the specific random number that was chosen isn't in the list of levels (that holds the build indexes), then keep randomly choosing
                {
                    randomSceneNum = Random.Range(0, scenesListLength);
                    Debug.Log("Num chosen " + randomSceneNum); //THIS IS STILL AN ISSUE NOT LOADING CORRECT THING
                    if (chosenScenesListLength > 0)
                    {
                        if (CheckChosenNum(randomSceneNum))
                        {
                            levelTransitionManager.AddChosenScene(randomSceneNum);
                            levelTransitionManager.SetLevelIndex(randomSceneNum);
                            available = true;
                        }             
                    }
                    else
                    {
                        levelTransitionManager.AddChosenScene(randomSceneNum);
                        levelTransitionManager.SetLevelIndex(randomSceneNum);
                        available = true;
                    }
                }
                if (fillPlayerHealth)
                {
                    playerHealthManager.SetCurrentHealth(playerHealthManager.GetMaxHealth()); //resets the player's health to full if the fillPlayerHealth boolean is selected
                }
                levelTransitionManager.FadeToLevel(); //loads the randomly selected level
            }
            else
            {
                levelTransitionManager.SetLevelIndex(SceneManager.sceneCountInBuildSettings);
                levelTransitionManager.FadeToLevel();
            }
        }
        else
        {
            if (levelToLoad == "GameOverScreen")
            {
                characterSelector.TurnOffCanvas();
            }
            SceneManager.LoadScene(levelToLoad); //loads a selected scene since random selection is not the desired functionality
        }
    }

    private bool CheckChosenNum(int numToCheck)
    {
        for (int i = 0; i < chosenScenesListLength; i++)
        {
            if (numToCheck == levelTransitionManager.GetChosenScenesList()[i])
            {
                return false;
            }
        }
        return true;
    }

    public float GetSwapLevelTime()
    {
        return swapLevelTime;
    }
}