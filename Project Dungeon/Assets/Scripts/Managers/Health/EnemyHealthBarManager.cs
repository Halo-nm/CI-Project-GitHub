using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarManager : MonoBehaviour //attached to the enemy
{
    //public Slider healthBar;

    public Vector3 localScale;

    private float maxHealth;
    private float currentHealth; //both these variables are set to floats so they don't round to "0" when calculating the enemy's current health

    EnemyHealthManager enemyHealthManager;

    void Start()
    {
        enemyHealthManager = GetComponentInParent<EnemyHealthManager>(); //get a reference to the EnemyHealthManager script that is ATTACHED to this object, hence why it's "GetComponent"
        maxHealth = enemyHealthManager.GetMaxHealth(); //sets a variable to the value of the enemy's max health
        localScale.x = maxHealth / 1000; //divided by 1000 because the sprite is very big
    }

    void Update()
    {
        currentHealth = enemyHealthManager.GetCurrentHealth(); //sets a variable to teh value of the enemy's max health
        localScale.x = currentHealth / 1000;
        transform.localScale = new Vector3 (localScale.x, 0.01f, 0); //sets the size of the health bar based on the enemies current health

        //healthBar.maxValue = maxHealth;
        //healthBar.value = currentHealth;
    }
}