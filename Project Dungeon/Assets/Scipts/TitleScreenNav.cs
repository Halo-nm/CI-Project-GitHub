using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenNav : MonoBehaviour
{
    [SerializeField] string levelToLoad = "";
    [SerializeField] Button startButton;
    [SerializeField] Button controlsButton;
    [SerializeField] Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadLevel);
        controlsButton.onClick.AddListener(MoveToControls);
        settingsButton.onClick.AddListener(MoveToSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    void MoveToControls()
    {
        
    }

    void MoveToSettings()
    {
        
    }


}