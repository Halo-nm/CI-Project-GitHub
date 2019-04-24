using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The actual ability
public class PracticeLog : MonoBehaviour
{
    [HideInInspector] public int pretendDamage = 1; //hidden in inspector because we don't want these values to be changed in the inspector, only those from "PracticeAbility"
    [HideInInspector] public float pretendRange = 20f; //still accessible from other classes
    [HideInInspector] public float pretendHitForce = 100f;

    public void Setup()
    {
        Debug.Log("Practice Ability Initialized!"); //normally would be done in the Start() function, but doesn't need to be anymore because it's called in "Ability"
    }

    public void DoSomething() //normally could be checked in the Update() function, but now can be called from "PracticeAbility"
    {
        Debug.Log("Practice Ability Casted!");
    }
}