using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] float nextAttackCounter = 1.5f; //the length of time between potential attacks

    private bool justAttacked = false;
    private float storeAttackCounter;
    private bool chargeInvulnerable;
    private bool rollInvulnerable;

    CharacterSelector characterSelector;
    Charge charge; //specific references to these abilities are needed for them to work (for now at least)
    Roll roll;

    void Start()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();

        storeAttackCounter = nextAttackCounter;
    }

    void Update()
    {
        if (justAttacked) //if the player was just attacked by the enemy, start the counter
        {
            nextAttackCounter -= Time.deltaTime;
        }

        if (nextAttackCounter <= 0f) //if the counter ends, the enemy did not just attack and the counter is reset
        {
            justAttacked = false;
            nextAttackCounter = storeAttackCounter;
        }

        if (characterSelector.GetCharacterActive()) //checks if the character is active
        {
            charge = characterSelector.GetCharacterObject().GetComponentInChildren<Charge>(); //retrieved from the player's weapon
            roll = characterSelector.GetCharacterObject().GetComponentInChildren<Roll>();
            chargeInvulnerable = charge.GetInvulnerable();
            rollInvulnerable = roll.GetInvulnerable();
        }
    }

    private void OnCollisionStay2D(Collision2D other) //if the player collides with the enemy, damage may be dealed to the player (CollisionStay just in case the player stays next to the enemy)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!justAttacked) //if the player wasn't just attacked by this enemy, hurt the player
            {
                if (!chargeInvulnerable && !rollInvulnerable)
                {
                    other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
                    justAttacked = true; //the enemy just attacked the player
                }
            }
        }
    }
}