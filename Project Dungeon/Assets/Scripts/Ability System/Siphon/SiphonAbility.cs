using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Siphon")]
public class SiphonAbility : Ability
{
    [Header("Specific Settings")]
    public int healthToReturn = 5;

    Siphon siphon;

    public override void Initialize(GameObject obj)
    {
        siphon = obj.GetComponent<Siphon>();
        siphon.healthToReturn = healthToReturn;
        siphon.Setup();
    }

    public override void TriggerAbility()
    {
        siphon.PerformSiphon();
    }
}