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

    PlayerController playerController;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    
    public void PerformBloodrush()
    {
        StartCoroutine(BuffTimer()); //calls the coroutine defined below to activate the buff temporarily
    }

    IEnumerator BuffTimer() //coroutine that works as a timer
    {
        float storedMoveSpeed = playerController.moveSpeed; //locally stores the value of the player's current move speed before it gets altered
        float storedAttackTime = playerController.attackTime; //locally stores the value of the player's current attack time before it gets altered

        playerController.moveSpeed *= moveSpeedMultiplier; //increases the move speed in the PlayerController script
        playerController.attackTime /= attackTimeDivisor; //decreases the attack time in the PlayerController script

        yield return new WaitForSeconds(buffDuration); //keeps buffs active for as long as the buff duration time

        playerController.moveSpeed = storedMoveSpeed; //sets the move speed of the player back to normal
        playerController.attackTime = storedAttackTime; //sets the attack speed of the player back to normal
    }
}