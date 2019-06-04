using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    [HideInInspector] public float dashSpeed;
    [HideInInspector] public float dashTime;
    [HideInInspector] public float invulnerableCounter = 1f;
    [HideInInspector] public float speedBuffTimer = 3;
    [HideInInspector] public float speedAmount = 1.5f;
    PlayerController playerController;
    HurtPlayer hurtPlayer;
    CharacterSelector characterSelector;

    private bool invulnerable;
    private bool dashing = false;

    private float storedMoveSpeed;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();
        hurtPlayer = FindObjectOfType<HurtPlayer>();
        characterSelector = FindObjectOfType<CharacterSelector>();

        storedMoveSpeed = playerController.GetMoveSpeed(); //locally stores the value of the player's current move speed before it gets altered
    }


    public void PerformTeleport()
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
        playerController.myRigidbody.velocity = playerController.lastMove * dashSpeed*(-1); //reverse position

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
        StartCoroutine(SpeedBoost());
    }
    IEnumerator InvulnerbleTimer()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerableCounter);
        invulnerable = false;
    }
    IEnumerator SpeedBoost()
    {
        playerController.SetMoveSpeed(storedMoveSpeed * speedAmount);
        yield return new WaitForSeconds(speedBuffTimer);
        playerController.SetMoveSpeed(storedMoveSpeed);
    }
    public bool GetDashing()
    {

        return dashing;
    }

    public bool GetInvulnerable()
    {
        return invulnerable;
    }
}