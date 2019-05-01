using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Charge")]
public class ChargeAbility : Ability
{
    [Header("Specific Settings")]
    public float moveSpeedMultiplier = 1.3f;
    public float superChargeExample = 50f;

    Charge charge;

    public override void Initialize(GameObject obj)
    {
        charge = obj.GetComponent<Charge>();

        charge.Setup();
    }

    public override void TriggerAbility()
    {
        charge.PerformCharge();
    }
}