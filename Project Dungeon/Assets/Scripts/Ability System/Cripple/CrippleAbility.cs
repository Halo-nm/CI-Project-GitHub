using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Cripple")]
public class CrippleAbility : Ability
{
    [Header("Specific Settings")]
    public GameObject crippleTrap;
    public int damageToDeal = 5;
    public float speedDivisor = 2f;
    public float slowedDuration = 3f;
    public float maxTrapLifetime = 10f;

    Cripple cripple;

    public override void Initialize(GameObject obj)
    {
        cripple = obj.GetComponent<Cripple>();
        cripple.crippleTrap = crippleTrap;
        cripple.damageToDeal = damageToDeal;
        cripple.speedDivisor = speedDivisor;
        cripple.slowedDuration = slowedDuration;
        cripple.maxTrapLifetime = maxTrapLifetime;
        cripple.Setup();
    }

    public override void TriggerAbility()
    {
        cripple.PerformCripple();
    }
}