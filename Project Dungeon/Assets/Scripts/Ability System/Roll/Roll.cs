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
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            playerController.myRigidbody.velocity = playerController.lastMove * dashSpeed;
        }
        else
        {
            playerController.myRigidbody.velocity = new Vector2(0,0);
        }
            
      
    }
}