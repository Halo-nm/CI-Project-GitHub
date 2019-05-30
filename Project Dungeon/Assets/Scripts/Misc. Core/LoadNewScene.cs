
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] string levelToLoad = "";
    [SerializeField] bool selectRandomScene = true;
    [SerializeField] bool returnPlayerHealth = true;
    [SerializeField] float swapLevelTime = 2f;

    private int scenesListLength;
    private int chosenScenesListLength;
    private bool gameOver = false;

    private bool titleScreen = false;

    PlayerHealthManager playerHealthManager;
    CharacterSelector characterSelector;
    AudioManager audioManager;
    PlayerStartPoint playerStartPoint;
    LevelTransitionManager levelTransitionManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerStartPoint = FindObjectOfType<PlayerStartPoint>();
    }

    void Update()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        levelTransitionManager = FindObjectOfType<LevelTransitionManager>();

        if (characterSelector != null) //checks if characterSelector is active/not destroyed
        {
            if (characterSelector.GetCharacterActive()) //checks if the character is active
            {
                playerHealthManager = characterSelector.GetCharacterObject().GetComponent<PlayerHealthManager>(); //gets the current player instance's health manager
            }
        }

        scenesListLength = levelTransitionManager.GetScenesList().Count;
        chosenScenesListLength = levelTransitionManager.GetChosenScenesList().Count;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //checks if the player was the object that collided with the gameobject the script is attached to
        {
            if (gameOver == false) //if the game is over, then the UI would be disabled, so the the below function wouldn't be able to be run
            {
                characterSelector.StartHidePlayerTimer();
            }
            StartCoroutine(SwapLevelTimer());
        }
    }

    IEnumerator SwapLevelTimer()
    {
        if (!titleScreen)
        {
            characterSelector.GetCharacterObject().SetActive(false);
        }

        yield return new WaitForSeconds(swapLevelTime);

        if (selectRandomScene) //if the selectRandomScene boolean is active, then the gameobject the script is attached to wants to randomly load levels from a list
        {
            if (scenesListLength > 0 && (scenesListLength != chosenScenesListLength)) //if the array doesn't have any levels to select from, the code will not be run to avoid any errors
            {
                int randomSceneNum;
                bool available = false;
                while (!available) //if the specific random number that was chosen isn't in the list of levels (that holds the build indexes), then keep randomly choosing
                {
                    randomSceneNum = Random.Range(1, scenesListLength + 1); //set to start at one since the Title Screen's index is 0 //had to add a +1 since the starting point was changed

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
                if (!titleScreen && returnPlayerHealth)
                {
                    playerHealthManager.SetCurrentHealth(playerHealthManager.GetCurrentHealth() + 50); //returns the player's health to the specified value if the fillPlayerHealth boolean is selected
                    //playerHealthManager.SetCurrentHealth(playerHealthManager.GetMaxHealth()); //returns the player's health to full if the fillPlayerHealth boolean is selected
                }
                levelTransitionManager.FadeToLevel(); //loads the randomly selected level
            }
            else //will load the VictoryScreen if all levels are complete
            {
                gameOver = true;
                characterSelector.TurnOffCanvas();
                levelTransitionManager.SetLevelIndex(SceneManager.sceneCountInBuildSettings - 1); //since the build index starts at 0, need to -1 to access the last spot of the build list
                levelTransitionManager.FadeToLevel();
            }
        }
        else
        {
            if (levelToLoad == "GameOverScreen") //string reference is slightly dangerous, but works fine
            {
                gameOver = true;
                characterSelector.TurnOffCanvas();
            }
            SceneManager.LoadScene(levelToLoad); //loads a selected scene since random selection is not the desired functionality
        }
    }

    public void ChooseRandomLevel() //set up solely for the Title Screen button to access
    {
        StartCoroutine(SwapLevelTimer());
    }

    public void SetTitleScreenBool(bool status)
    {
        titleScreen = status;
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