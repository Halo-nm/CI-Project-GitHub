using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siphon : MonoBehaviour //make sure to attach to the player!
{

    [HideInInspector] public int healthToReturn;

    PlayerHealthManager playerHealthManager;
    int maxHealth;
    int currentHealth;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        maxHealth = playerHealthManager.GetMaxHealth();
    }

    public void Update()
    {
        currentHealth = playerHealthManager.GetCurrentHealth();
    }

    public void PerformSiphon()
    {
        if (currentHealth + healthToReturn >= maxHealth) //if returning health would make the players health greater than 100, set the current health to 100
        {
            playerHealthManager.SetCurrentHealth(maxHealth);
        }
        else
        {
            playerHealthManager.SetCurrentHealth(currentHealth + healthToReturn);
        }
    }
}