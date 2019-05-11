using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarManager : MonoBehaviour //attached to the enemy
{
    public Slider healthBar;

    private float maxHealth;
    private float currentHealth; //both these variables are set to floats so they don't round to "0" when calculating the enemy's current health

    EnemyHealthManager enemyHealthManager;

    void Start()
    {
        enemyHealthManager = GetComponent<EnemyHealthManager>(); //get a reference to the EnemyHealthManager script that is ATTACHED to this object, hence why it's "GetComponent"
    }

    void Update()
    {
        maxHealth = enemyHealthManager.GetMaxHealth(); //sets a variable to the value of the enemy's max health
        currentHealth = enemyHealthManager.GetCurrentHealth(); //sets a variable to teh value of the enemy's max health
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }
}