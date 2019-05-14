using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] int healthToReturn = 10;

    PlayerHealthManager playerHealthManager;

    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerHealthManager.SetCurrentHealth(playerHealthManager.GetCurrentHealth() + healthToReturn);
        }
    }
}
