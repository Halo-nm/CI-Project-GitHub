using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;

    public PlayerHealthManager playerHealthManager;
    CharacterSelector characterSelector;
    GameObject character;

    void Start()
    {
        playerHealthManager = characterSelector.GetCharacterObject().GetComponent<PlayerHealthManager>();
    }

    void Update()
    {
        healthBar.maxValue = playerHealthManager.GetMaxHealth();
        healthBar.value = playerHealthManager.GetCurrentHealth();
    }
}
