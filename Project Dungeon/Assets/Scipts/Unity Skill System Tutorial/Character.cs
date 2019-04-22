using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")] //creates a menu options to create a character scriptable object
public class Character : ScriptableObject //not a component (not attached to anything in the scene)
{
    public string characterName = "Default";
    public int startingHP = 100; //types of things maybe put in a character
    public Ability[] characterAbilities; //an array to hold the ability scriptable objects


}
