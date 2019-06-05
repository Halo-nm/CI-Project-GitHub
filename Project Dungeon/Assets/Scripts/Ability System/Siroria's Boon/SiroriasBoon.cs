using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiroriasBoon : MonoBehaviour
{

    [HideInInspector] public float moveSpeedMultiplier;

    PlayerController playerController;

    public void Setup() //performs the same actions as MonoBehaviour's Start() function
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    
    public void PerformSiroriasBoon()
    {
        
    }
}