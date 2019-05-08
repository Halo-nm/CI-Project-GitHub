using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] int playerMaxHealth;
    [SerializeField] int playerCurrentHealth;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //playerCurrentHealth = playerMaxHealth;
            //gameObject.SetActive(true);
        }
    }

    public void HurtPlayer(int damageToDeal)
    {
        playerCurrentHealth -= damageToDeal;
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
