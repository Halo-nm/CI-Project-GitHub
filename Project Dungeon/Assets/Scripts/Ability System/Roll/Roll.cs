using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roll : MonoBehaviour
{
    [HideInInspector] public float dashSpeed;
    [HideInInspector] public float dashTime;
    [HideInInspector] public float startDashTime;

    PlayerController playerController;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();
    }


    public void PerformRoll()
    {
        StartCoroutine(RollTimer());
    }
    IEnumerator RollTimer() //coroutine that works as a timer
    {
        playerController.myRigidbody.velocity = playerController.lastMove * dashSpeed;
        System.Console.WriteLine("running");

        yield return new WaitForSeconds(dashTime); //dash duration
        playerController.myRigidbody.velocity = new Vector2(0, 0);

    }
}
