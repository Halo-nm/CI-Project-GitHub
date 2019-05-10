using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int playerMaxHealth;
    [SerializeField] int playerCurrentHealth;
    [SerializeField] string endGameScene = "GameOverScreen"; //the scene to load when the player dies

    CharacterSelector characterSelector;
    LoadNewScene loadNewScene;

    void Start()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        loadNewScene = FindObjectOfType<LoadNewScene>();

        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            characterSelector.TurnOffCanvas();
            loadNewScene.LoadEndGameScene(endGameScene);
            gameObject.SetActive(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload the current scene
        }
    }

    public void HurtPlayer(int damageToDeal)
    {
        playerCurrentHealth -= damageToDeal;
        if (playerCurrentHealth < 0)
        {
            playerCurrentHealth = 0;
        }
    }

    public int GetMaxHealth()
    {
        return playerMaxHealth;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public int GetCurrentHealth()
    {
        return playerCurrentHealth;
    }

    public void SetCurrentHealth(int updatedCurrentPlayerHealth)
    {
        playerCurrentHealth = updatedCurrentPlayerHealth;
    }
}
