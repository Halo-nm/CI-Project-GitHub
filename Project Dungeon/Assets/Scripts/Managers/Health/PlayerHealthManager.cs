using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int playerMaxHealth;
    [SerializeField] int playerCurrentHealth;

    private bool gameOverScreenLoaded;

    CharacterSelector characterSelector;
    AudioManager audioManager;
    LevelTransitionManager levelTransitionManager;

    void Start()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        audioManager = FindObjectOfType<AudioManager>();

        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        levelTransitionManager = FindObjectOfType<LevelTransitionManager>();
        if (playerCurrentHealth <= 0 && !gameOverScreenLoaded)
        {
            gameOverScreenLoaded = true;
            characterSelector.SetCharacterActive(false);
            characterSelector.TurnOffCanvas();
            gameObject.GetComponent<PlayerController>().enabled = false; //not a clean way of disabling the player once dead, but works for now
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.Find("Weapon").gameObject.SetActive(false);
            StartCoroutine(DeathTime());
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

    IEnumerator DeathTime() //has the player wait a few seconds before GAME OVER is displayed in order to give time for any death animations/sounds
    {
        audioManager.PlaySoundFXAudio(audioManager.GetDeathSound()); //NOT playing the audio for some reason
        yield return new WaitForSeconds(3); //plays for the length of the audio clip
        levelTransitionManager.SetLevelIndex(SceneManager.sceneCountInBuildSettings - 1);  //the Game Over screen is the last scene in the scene index but needs to be -1 because the index starts at 1
        levelTransitionManager.FadeToLevel();
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
        if (updatedCurrentPlayerHealth > playerMaxHealth) //if updating the player's health would make the players health greater than 100, set the current health to 100
        {
            playerCurrentHealth = playerMaxHealth;
        }
        else
        {
            playerCurrentHealth = updatedCurrentPlayerHealth;
        }
    }
}
