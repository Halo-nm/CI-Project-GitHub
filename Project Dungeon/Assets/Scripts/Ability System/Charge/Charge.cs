using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Charge : MonoBehaviour
{
   [HideInInspector] public int dashDamage = 5;
   [HideInInspector] public float dashSpeed;
   [HideInInspector] public float dashTime;
   [HideInInspector] public float invulnerableCounter = 1f;

    PlayerController playerController;
    HurtPlayer hurtPlayer;
    CharacterSelector characterSelector;

    private bool invulnerable;
    private bool dashing = false;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        hurtPlayer = FindObjectOfType<HurtPlayer>();
        characterSelector = FindObjectOfType<CharacterSelector>();
    }

    void Update()
    {
        playerController = FindObjectOfType<PlayerController>(); //appeared to not be making the player invicible during the dash when this line is in Setup()
    }


    public void PerformCharge()
    {
        StartCoroutine(DashTimer());
        StartCoroutine(InvulnerbleTimer());
    }

    IEnumerator DashTimer()
    {
        BoxCollider2D[] playerColliders = characterSelector.GetCharacterObject().GetComponentsInChildren<BoxCollider2D>();
        Vector2 storeSwordColliderSize = new Vector2();
        dashing = true;
        float storeDashTime = dashTime;
        playerController.SetAbilityActive(true);
        playerController.myRigidbody.velocity = playerController.lastMove * dashSpeed;

        for (int i = 0; i < playerColliders.Length; i++)
        {
            if (i == 1) //finds the second collider available which is the sword's //ugly way to do this since it's hardcoded
            {
                storeSwordColliderSize = playerColliders[i].size;
                playerColliders[i].size = new Vector2(1, 1);
            }
        }

        yield return new WaitForSeconds(dashTime);

        for (int i = 0; i < playerColliders.Length; i++) //reverses what was done
        {
            if (i == 1)
            {
                playerColliders[i].size = storeSwordColliderSize;
            }
        }

        playerController.SetAbilityActive(false);
        dashTime = storeDashTime;
        dashing = false;
    }
    IEnumerator InvulnerbleTimer()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerableCounter);
        invulnerable = false;
    }

    public bool GetDashing()
    {
        return dashing;
    }

    public int GetDashDamage()
    {
        return dashDamage;
    }

    public bool GetInvulnerable()
    {
        return invulnerable;
    }
}
