using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Charge : MonoBehaviour
{
   [HideInInspector] public float dashSpeed;
   [HideInInspector] public float dashTime;
   [HideInInspector] public float startDashTime;

    PlayerController playerController;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    
    public void PerformCharge()
    {
        StartCoroutine(ChargeTimer());  
    }
    IEnumerator ChargeTimer() //coroutine that works as a timer
    {
        playerController.myRigidbody.velocity = playerController.lastMove * dashSpeed;


        yield return new WaitForSeconds(dashTime); //dash duration
        playerController.myRigidbody.velocity = new Vector2(0, 0);

    }
}
