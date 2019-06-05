using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodrush : MonoBehaviour
{

    [HideInInspector] public float moveSpeedMultiplier;
    [HideInInspector] public float attackTimeDivisor;
    [HideInInspector] public float buffDuration = 5f;

    private float bloodrushCounter;
    private bool bloodrushReady = true;

    private float storedMoveSpeed;
    private float storedAttackTime;

    PlayerController playerController;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();

        storedMoveSpeed = playerController.GetMoveSpeed(); //locally stores the value of the player's current move speed before it gets altered
        storedAttackTime = playerController.GetAttackTime(); //locally stores the value of the player's current attack time before it gets altered
    }

    
    public void PerformBloodrush()
    {
        StartCoroutine(BuffTimer()); //calls the coroutine defined below to activate the buff temporarily
    }

    IEnumerator BuffTimer() //coroutine that works as a timer
    {
        playerController.SetMoveSpeed(storedMoveSpeed * moveSpeedMultiplier); //increases the move speed in the PlayerController script
        playerController.SetAttackTime(storedAttackTime / attackTimeDivisor); //decreases the attack time in the PlayerController script

        yield return new WaitForSeconds(buffDuration); //keeps buffs active for as long as the buff duration time

        playerController.SetMoveSpeed(storedMoveSpeed); //sets the move speed of the player back to normal
        playerController.SetAttackTime(storedAttackTime); //sets the attack speed of the player back to normal
    }
}