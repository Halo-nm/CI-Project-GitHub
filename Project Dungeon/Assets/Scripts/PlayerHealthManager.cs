using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int playerMaxHealth;
    [SerializeField] int playerCurrentHealth;
    [SerializeField] AudioClip deathSound;

    CharacterSelector characterSelector;
    AudioManager audioManager;

    void Start()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        audioManager = FindObjectOfType<AudioManager>();

        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            StartCoroutine(DeathTime());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //playerCurrentHealth = playerMaxHealth;
            //gameObject.SetActive(true);
        }
    }

    IEnumerator DeathTime() //has the player wait a few seconds before GAME OVER is displayed in order to give time for any death animations/sounds
    {
        audioManager.PlayAudio(deathSound); //NOT playing the audio for some reason
        gameObject.SetActive(false); //disables the player
        characterSelector.TurnOffHUDElements(); //turns off all elements of the HUD
        yield return new WaitForSeconds(3); //plays for the length of the audio clip
        SceneManager.LoadScene("GameOverScreen"); //loads the GameOverScreen scene
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
