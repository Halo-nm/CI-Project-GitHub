using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Charge")]
public class ChargeAbility : Ability
{
    [Header("Specific Settings")]
    public float dashSpeed = 1.3f;
    public float dashTime = 1;
    public float startDashTime = 1;
    Charge charge;

    public override void Initialize(GameObject obj)
    {
        charge = obj.GetComponent<Charge>();
        charge.dashSpeed = dashSpeed;
        charge.dashTime = dashTime;
        charge.startDashTime = startDashTime;
        charge.Setup();
    }

    public override void TriggerAbility()
    {
        charge.PerformCharge();
    }
}