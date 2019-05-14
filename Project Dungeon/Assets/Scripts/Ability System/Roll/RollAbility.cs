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
    Charge charge;

    public override void Initialize(GameObject obj)
    {
        charge = obj.GetComponent<Charge>();
        charge.dashSpeed = dashSpeed;
        charge.dashTime = dashTime;
        charge.invulnerableCounter = invulnerbleCounter;
        charge.Setup();
    }

    public override void TriggerAbility()
    {
        charge.PerformCharge();
    }
}