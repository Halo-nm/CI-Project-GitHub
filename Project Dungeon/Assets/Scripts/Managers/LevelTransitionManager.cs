using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private static bool levelTransitionManagerExists;

    private List<int> scenesList = new List<int>(); //int list of levels to randomly select from
    private List<int> chosenScenesList = new List<int>(); //list of scenes already chosen
    private int levelIndex;

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
    }

    private void SelectRandomLevel()
    {
        int sceneCountLength = SceneManager.sceneCountInBuildSettings; //temporary storge of how many scenes are in the build settings (discounts the first and last scene, which should be the title and game over screen)
        for (int i = 0; i < sceneCountLength - 2; i++) //IMPORTANT: set to -3 so that it excludes the Title Screen, Victory Screen, and Game Over Screen in the build settings
        {
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
}
