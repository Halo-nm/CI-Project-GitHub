using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Teleport")]
public class TeleportAbility : Ability
{
    [Header("Specific Settings")]
    public float dashSpeed = 1.3f;
    public float dashTime = 1;
    public float invulnerbleCounter = 1f;
    public float speedBuffTimer = 3f;
    public float speedAmount = 1.5f;
    Teleport teleport;

    public override void Initialize(GameObject obj)
    {
        teleport = obj.GetComponent<Teleport>();
        teleport.dashSpeed = dashSpeed;
        teleport.dashTime = dashTime;
        teleport.invulnerableCounter = invulnerbleCounter;
        teleport.speedBuffTimer = speedBuffTimer;
        teleport.speedAmount = speedAmount;
        teleport.Setup();
    }

    public override void TriggerAbility()
    {
        teleport.PerformTeleport();
    }
}