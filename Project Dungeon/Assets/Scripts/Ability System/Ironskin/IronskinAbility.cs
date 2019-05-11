using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Bloodrush")]
public class IronskinAbility : Ability
{
    [Header("Specific Settings")]
    public float moveSpeedMultiplier = 1.3f;
    public int shieldHealth = 20;
    public float buffDuration = 5f;

    Ironskin ironskin;

    public override void Initialize(GameObject obj)
    {
        ironskin = obj.GetComponent<Ironskin>();

        ironskin.moveSpeedMultiplier = moveSpeedMultiplier;
        ironskin.shieldHealth = shieldHealth;
        ironskin.buffDuration = buffDuration;

        ironskin.Setup();
    }

    public override void TriggerAbility()
    {
        ironskin.PerformIronskin();
    }
}