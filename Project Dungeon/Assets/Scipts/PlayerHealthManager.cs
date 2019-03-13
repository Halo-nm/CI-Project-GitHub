using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
    }

    public void HurtPlayer(int damageToDeal)
    {
        playerCurrentHealth -= damageToDeal;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
