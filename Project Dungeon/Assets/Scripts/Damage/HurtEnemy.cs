using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] GameObject damageBurst;
    [SerializeField] Transform hitPoint;

    PlayerController playerController;
    Siphon siphon;

    private bool successfulHit = false;
    private bool justAttacked = false;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        siphon = FindObjectOfType<Siphon>();
    }

    void Update()
    {
        if (!playerController.GetPlayerAttacking()) //essentially gets the animation time so the player can attack once the animation is finished
        {
            justAttacked = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!justAttacked && playerController.GetPlayerAttacking() && other.gameObject.tag == "Enemy") //if the player didn't just attack, is currently in the attack animation, and the object being attacked is tagged as "Enemy," the HurtEnemy logic is run
        {
            try //sloppily done just in case siphon isn't active on that specific character
            {
                if (siphon.GetIsSiphonActive()) //checks if siphon was recently triggered
                {
                    successfulHit = true; //the hit was successfully made
                }
            }
            catch
            {
                //pass
            }
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToDeal);
            GameObject tempBurst = Instantiate(damageBurst, other.transform.position, other.transform.rotation);
            Destroy(tempBurst, 1.0f);
            justAttacked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //used specifically for an ability
    {
        if (other.gameObject.tag == "Enemy")
        {
            try //hastily done to fix an issue where an error was being thrown during level swaps when the ability is on cooldown
            {
                if (FindObjectOfType<Charge>().GetDashing())
                {
                    other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(FindObjectOfType<Charge>().GetDashDamage());
                    GameObject tempBurst = Instantiate(damageBurst, other.transform.position, other.transform.rotation);
                    Destroy(tempBurst, 1.0f);
                }
            }
            catch
            {
                //pass
            }
        }
    }

    public bool GetSuccessfulHit() //returns whether the hit was successful or not
    {
        return successfulHit;
    }

    public void SetSuccessfulHit() //sets back to false
    {
        successfulHit = false;
    }
}
