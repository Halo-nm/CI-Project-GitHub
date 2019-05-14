using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] int healthToReturn = 10;

    PlayerHealthManager playerHealthManager;

    private int maxHealth;
    private int currentHealth;

    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();

        maxHealth = playerHealthManager.GetMaxHealth();
    }

    void Update()
    {
        currentHealth = playerHealthManager.GetCurrentHealth();
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
