using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject player; //used to spawn the player when the button is selected
    public Vector2 playerSpawnPosition = new Vector2(0, 0); //sets the spawn position4

    public Character[] characters; //character options that are set in the inspector

    public GameObject characterSelectPanel; //grabbed to be used to turn on and off
    public GameObject abilityPanel;

    public void OnCharacterSelect(int characterChoice) //function called when the button is pressed //parameter is passed by the button that was clicked
    {
        characterSelectPanel.SetActive(false); //hidden when first called
        abilityPanel.SetActive(true); //activated when first called
        GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject; //casted as a GameObject //Quaternion.identity returns the rotation of the original prefab
        WeaponMarker weaponMarker = spawnedPlayer.GetComponentInChildren<WeaponMarker>(); //search (starting from the spawnedPlayer object) down the heirachy until it finds a weaponMarker component attached to a game object //used to find the weapon marker script in the heirarchy
        AbilityCooldown[] cooldownButtons = GetComponentsInChildren<AbilityCooldown>(); //look through the children attached to the game object this script is attached to and search down the heirachy and store ANY ability cooldown scripts it finds //then stored in this array
        Character selectedCharacter = characters[characterChoice]; //character is selected based on which button the player picked (such as 0) //then gets the index character of the array (spot 0 in that case)

        for (int i = 0; i < cooldownButtons.Length; i++) //loops through the array until all have been initialzed
        { //*IMPORTANT* If there are too many abilities, then some will get ignored because there are too many abilities //too few abilities will create blank buttons //need to account for this
            cooldownButtons[i].Initialize(selectedCharacter.characterAbilities[i], weaponMarker.gameObject); //each character has an array of character abilities //the selected ability is the one in character abilities spot i //the weapon holder is the first object that was found that had a weapon marker
        }
    }


}
