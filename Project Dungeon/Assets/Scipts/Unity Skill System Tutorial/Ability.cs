using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The scriptable object for abilities
//Scriptable Object Callbacks Received: OnEnable, OnDisable, and OnDestroy
public abstract class Ability : ScriptableObject //is an abstract class because the script contains functions that have no implementation so other abilities can use the functions differently (can "fill in" what they do in the base classes)
{ //since the script isn't derived from MonoBehaviour, built-in functions such as Start() and Update() wouldn't do their normal "job"
    public string abilityName = "New Ability";
    public Sprite abilitySprite;
    public AudioClip abilitySound;
    public float abilityBaseCooldown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility(); //all abilities are "triggered" but have a different effect when triggered
}
