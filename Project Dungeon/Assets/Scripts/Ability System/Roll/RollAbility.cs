using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Charge")]
public class RollAbility : Ability
{
    [Header("Specific Settings")]
    public float dashSpeed = 1.3f;
    public float dashTime = 1;
    public float invulnerbleCounter = 1f;
    public float speedBuffTimer = 3f;
    public float speedAmount = 1.5f;
    Roll roll;

    public override void Initialize(GameObject obj)
    {
        roll = obj.GetComponent<Roll>();
        roll.dashSpeed = dashSpeed;
        roll.dashTime = dashTime;
        roll.invulnerableCounter = invulnerbleCounter;
        roll.speedBuffTimer = speedBuffTimer;
        roll.speedAmount = speedAmount;
        roll.Setup();
    }

    public override void TriggerAbility()
    {
        roll.PerformRoll();
    }
}