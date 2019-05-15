using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] int healthToReturn = 10;

    PlayerHealthManager playerHealthManager;
    CharacterSelector characterSelector;

    private int maxHealth;
    private int currentHealth;

    void Start()
    {
        
        characterSelector = FindObjectOfType<CharacterSelector>();
    }

    void Update()
    {
        try
        {
            playerHealthManager = characterSelector.GetCharacterObject().GetComponent<PlayerHealthManager>(); //gets the current player instance's health manager
            maxHealth = playerHealthManager.GetMaxHealth();
            currentHealth = playerHealthManager.GetCurrentHealth();
        }
        catch
        {
            //pass
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentHealth + healthToReturn >= maxHealth) //if returning health would make the players health greater than 100, set the current health to 100
            {
                playerHealthManager.SetCurrentHealth(maxHealth);
            }
            else
            {
                playerHealthManager.SetCurrentHealth(currentHealth + healthToReturn);
            }
            Destroy(gameObject);
        }
    }
}
