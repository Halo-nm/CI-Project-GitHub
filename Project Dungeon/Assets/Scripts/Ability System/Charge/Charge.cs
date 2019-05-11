using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Charge : MonoBehaviour
{
   [HideInInspector] public float dashSpeed;
   [HideInInspector] public float dashTime;
   [HideInInspector] public float invulnerbleCounter = 1f;

    PlayerController playerController;
    HurtPlayer hurtPlayer;
    CharacterSelector characterSelector;

    private bool dashing = false;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();
        hurtPlayer = FindObjectOfType<HurtPlayer>();
        characterSelector = FindObjectOfType<CharacterSelector>();

    }


    public void PerformCharge()
    {
        StartCoroutine(DashTimer());
        StartCoroutine(InvulnerbleTimer());
    }

    IEnumerator DashTimer()
    {
        dashing = true;
        float storeDashTime = dashTime;
        hurtPlayer.SetInvulnerable(true);
        playerController.SetAbilityActive(true);
        playerController.myRigidbody.velocity = playerController.lastMove * dashSpeed;
        yield return new WaitForSeconds(dashTime);
        playerController.SetAbilityActive(false);
        dashTime = storeDashTime;
        dashing = false;
    }
    IEnumerator InvulnerbleTimer()
    {
        hurtPlayer.SetInvulnerable(true);
        yield return new WaitForSeconds(invulnerbleCounter);
        hurtPlayer.SetInvulnerable(false);
    }

    public bool GetDashing()
    {
        return dashing;
    }

}
