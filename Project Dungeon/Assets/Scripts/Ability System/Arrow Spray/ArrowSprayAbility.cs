using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ArrowSpray")]
public class ArrowSprayAbility : Ability
{ 
    [Header("Specific Settings")]
    public GameObject arrowPrefab;
    public int damagePerArrow = 5;
    public float arrowSpeed = 25f;
    public float degreeBetweenSplit = 30f;

    private ArrowSpray arrowSpray;

    public override void Initialize(GameObject obj)
    {
        arrowSpray = obj.GetComponent<ArrowSpray>();
        arrowSpray.arrowPrefab = arrowPrefab;
        arrowSpray.damagePerArrow = damagePerArrow;
        arrowSpray.arrowSpeed = arrowSpeed;
        arrowSpray.degreeBetweenSplit = degreeBetweenSplit;
        arrowSpray.Setup();
    }

    public override void TriggerAbility()
    {
        arrowSpray.PerformArrowSpray();
    }
}
