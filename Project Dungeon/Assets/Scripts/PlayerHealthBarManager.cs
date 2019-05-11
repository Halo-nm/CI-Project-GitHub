using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarManager : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;

    private float maxHealth;
    public float currentHealth; //both these variables are set to floats so they don't round to "0" when calculating the player's current health

    PlayerHealthManager playerHealthManager;
    CharacterSelector characterSelector;

    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>(); //get a reference to the PlayerHealthManager script
        characterSelector = FindObjectOfType<CharacterSelector>(); //get a reference to the CharacterSelector script
    }

    void Update()
    {
        try //put in a try, catch so an error isn't thrown during character selection
        {
            playerHealthManager = characterSelector.GetCharacterObject().GetComponent<PlayerHealthManager>(); //get the instantiated (or active) player's PlayerHealthManager script
            maxHealth = playerHealthManager.GetMaxHealth(); //sets a variable to teh value of the character's max health
            currentHealth = playerHealthManager.GetCurrentHealth(); //sets a variable to teh value of the character's max health
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
            healthText.text = "HP: " + ((currentHealth / maxHealth) * 100).ToString() + "%"; //sets the health text to the player's current health as a percentage

        }
        catch
        {
            //pass
        }
        
    }
}