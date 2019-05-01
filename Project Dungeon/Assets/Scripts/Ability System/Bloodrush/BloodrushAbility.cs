using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Bloodrush")]
public class BloodrushAbility : Ability
{
    [Header("Specific Settings")]
    public float moveSpeedMultiplier = 1.3f;
    public float attackTimeDivisor = 1.3f;
    public float buffDuration = 5f;

    Bloodrush bloodrush;

    public override void Initialize(GameObject obj)
    {
        bloodrush = obj.GetComponent<Bloodrush>();

        bloodrush.moveSpeedMultiplier = moveSpeedMultiplier;
        bloodrush.attackTimeDivisor = attackTimeDivisor;
        bloodrush.buffDuration = buffDuration;

        bloodrush.Setup();
    }

    public override void TriggerAbility()
    {
        bloodrush.PerformBloodrush();
    }
}