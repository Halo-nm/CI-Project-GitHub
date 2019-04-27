using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Bloodrush")]
public class SiroriasBoonAbility : Ability
{
    [Header("Specific Settings")]
    public float moveSpeedMultiplier = 1.3f;

    SiroriasBoon siroriasBoon;

    public override void Initialize(GameObject obj)
    {
        siroriasBoon = obj.GetComponent<SiroriasBoon>();

        siroriasBoon.Setup();
    }

    public override void TriggerAbility()
    {
        siroriasBoon.PerformSiroriasBoon();
    }
}