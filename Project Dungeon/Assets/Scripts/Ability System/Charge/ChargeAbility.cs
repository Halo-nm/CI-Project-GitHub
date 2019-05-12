using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Charge")]
public class ChargeAbility : Ability
{
    [Header("Specific Settings")]
    public int dashDamage = 5;
    public float dashSpeed = 1.3f;
    public float dashTime = 1;
    public float invulnerableCounter = 1f;
    Charge charge;

    public override void Initialize(GameObject obj)
    {
        charge = obj.GetComponent<Charge>();
        charge.dashDamage = dashDamage;
        charge.dashSpeed = dashSpeed;
        charge.dashTime = dashTime;
        charge.invulnerableCounter = invulnerableCounter;
        charge.Setup();
    }

    public override void TriggerAbility()
    {
        charge.PerformCharge();
    }
}