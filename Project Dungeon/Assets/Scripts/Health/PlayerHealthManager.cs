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
    AudioManager audioManager;
    //LoadNewScene loadNewScene;

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
            characterSelector.SetCharacterActive(false);
            characterSelector.TurnOffCanvas();
            //loadNewScene.LoadEndGameScene(endGameScene);
            //gameObject.SetActive(false);
            gameObject.GetComponent<PlayerController>().enabled = false; //not a clean way of disabling the player once dead, but works for now
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.Find("Weapon").gameObject.SetActive(false);
            StartCoroutine(DeathTime(endGameScene));
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

    IEnumerator DeathTime(string sceneToLoad) //has the player wait a few seconds before GAME OVER is displayed in order to give time for any death animations/sounds
    {
        audioManager.PlaySoundFXAudio(audioManager.GetDeathSound()); //NOT playing the audio for some reason
        yield return new WaitForSeconds(3); //plays for the length of the audio clip
        SceneManager.LoadScene(sceneToLoad);
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
