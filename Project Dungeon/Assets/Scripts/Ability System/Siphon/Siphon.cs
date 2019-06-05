using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siphon : MonoBehaviour //make sure to attach to the player!
{

    [HideInInspector] public int healthToReturn;

    PlayerHealthManager playerHealthManager;
    HurtEnemy hurtEnemy;

    private int maxHealth;
    private int currentHealth;
    private bool isSiphonActive = false;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        hurtEnemy = FindObjectOfType<HurtEnemy>();

        maxHealth = playerHealthManager.GetMaxHealth();
    }

    public void Update()
    {
        currentHealth = playerHealthManager.GetCurrentHealth();

        if (hurtEnemy.GetSuccessfulHit()) //checks if the hit was successful after triggering siphon
        {
            if (currentHealth + healthToReturn >= maxHealth) //if returning health would make the players health greater than 100, set the current health to 100
            {
                playerHealthManager.SetCurrentHealth(maxHealth);
            }
            else
            {
                playerHealthManager.SetCurrentHealth(currentHealth + healthToReturn);
            }
            hurtEnemy.SetSuccessfulHit();
            isSiphonActive = false;
        }
    }

    public void PerformSiphon()
    {
        isSiphonActive = true;
    }

    public bool GetIsSiphonActive()
    {
        return isSiphonActive;
    }
}