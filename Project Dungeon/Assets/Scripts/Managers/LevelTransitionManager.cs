using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    CharacterSelector characterSelector;

    private static bool levelTransitionManagerExists;

    private List<int> scenesList = new List<int>(); //int list of levels to randomly select from
    private List<int> chosenScenesList = new List<int>(); //list of scenes already chosen
    private int levelIndex;

    private string endTime;

    LoadNewScene loadNewScene;

    void Start()
    {
        if (!levelTransitionManagerExists) //if the UI doesn't exist in the current scene, don't destroy the UI between scene swapping
        {
            levelTransitionManagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SelectRandomLevel();
    }

    void Update()
    {
        loadNewScene = FindObjectOfType<LoadNewScene>();

        try //set up so the last instance of characterSelector can be found without throwing an error
        {
            characterSelector = FindObjectOfType<CharacterSelector>();
            endTime = characterSelector.GetCurrentTime(); //time is retrieved so it can be send the the end-of-the-game screen
        }
        catch
        {
            //pass
        }
    }

    private void SelectRandomLevel()
    {
        int sceneCountLength = SceneManager.sceneCountInBuildSettings; //temporary storge of how many scenes are in the build settings (discounts the first and last scene, which should be the title and game over screen)
        for (int i = 1; i < sceneCountLength - 2; i++) //IMPORTANT: set to -2 so that it excludes the Title Screen, Victory Screen, and Game Over Screen in the build settings
        { //starts at index 1 because that's where the Title Screen is
            scenesList.Add(i);
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelIndex);
        animator.SetTrigger("FadeIn");
    }

    public List<int> GetScenesList()
    {
        return scenesList;
    }

    public List<int> GetChosenScenesList()
    {
        return chosenScenesList;
    }

    public void AddChosenScene(int num)
    {
        chosenScenesList.Add(num);
    }

    public void SetLevelIndex(int index)
    {
        levelIndex = index;
    }

    public string GetEndTime()
    {
        return endTime;
    }
}
