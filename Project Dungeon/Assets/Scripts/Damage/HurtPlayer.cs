using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] float nextAttackCounter = 1.5f; //the length of time between potential attacks

    private bool invulnerable = false;
    private bool justAttacked = false;
    private float storeAttackCounter;

    void Start()
    {
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
    }

    private void OnCollisionStay2D(Collision2D other) //if the player collides with the enemy, damage may be dealed to the player (CollisionStay just in case the player stays next to the enemy)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!justAttacked) //if the player wasn't just attacked by this enemy, hurt the player
            {
                if (!invulnerable)
                {
                    other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
                    justAttacked = true; //the enemy just attacked the player
                }
            }
        }
    }

    public bool GetInvulnerable()
    {
        return invulnerable;
    }
    public void SetInvulnerable(bool status)
    {
        invulnerable = status;
    }
}