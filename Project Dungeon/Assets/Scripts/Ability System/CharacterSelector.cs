using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject warrior; //used to spawn the warrior when the button is selected
    public GameObject archer; //used to spawn the archer when the button is selected
    public GameObject mage; //used to spawn the mage when the button is selected

    private Vector2 playerSpawnPosition = new Vector2(0, 0); //sets the spawn position4

    private GameObject spawnedPlayer;
    private bool characterActive = false;

    public Character[] characters; //character options that are set in the inspector

    public Canvas UICanvas;

    public GameObject characterSelectPanel; //grabbed to be used to turn on and off
    public GameObject abilityPanel;

    private static bool UIExists; //static boolean that checks if a UI is present in the current scene

    PlayerHealthBarManager playerHealthBarManager;
    PlayerStartPoint playerStartPoint;
    LoadNewScene loadNewScene;

    void Start()
    {
        playerHealthBarManager = FindObjectOfType<PlayerHealthBarManager>(); //gets a reference to the PlayerHealthBarManager script
        playerStartPoint = FindObjectOfType<PlayerStartPoint>();

        if (playerStartPoint != null) //if there is a player start point present, change the player's starting position to its values
        {
            playerSpawnPosition = playerStartPoint.GetStartPosition(); //sets the player's spawn position to the position of the player start point game object to prevent camera drag on character spawn
        }

        if (!UIExists) //if the UI doesn't exist in the current scene, don't destroy the UI between scene swapping
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        loadNewScene = FindObjectOfType<LoadNewScene>();
    }

    public void OnCharacterSelect(int characterChoice) //function called when the button is pressed //parameter is passed by the button that was clicked
    {
        characterActive = true;
        playerHealthBarManager.healthBar.gameObject.SetActive(true);
        playerHealthBarManager.healthText.gameObject.SetActive(true);
        characterSelectPanel.SetActive(false); //hidden when first called
        abilityPanel.SetActive(true); //activated when first called
        if (characterChoice == 0)
        {
            spawnedPlayer = Instantiate(warrior, playerSpawnPosition, Quaternion.identity) as GameObject; //casted as a GameObject //Quaternion.identity returns the rotation of the original prefab
        }
        else if (characterChoice == 1)
        {
            spawnedPlayer = Instantiate(archer, playerSpawnPosition, Quaternion.identity) as GameObject;
        }
        else
        {
            spawnedPlayer = Instantiate(mage, playerSpawnPosition, Quaternion.identity) as GameObject;
        }
        WeaponMarker weaponMarker = spawnedPlayer.GetComponentInChildren<WeaponMarker>(); //search (starting from the spawnedPlayer object) down the heirachy until it finds a weaponMarker component attached to a game object //used to find the weapon marker script in the heirarchy
        AbilityCooldown[] cooldownButtons = GetComponentsInChildren<AbilityCooldown>(); //look through the children attached to the game object this script is attached to and search down the heirachy and store ANY ability cooldown scripts it finds //then stored in this array
        Character selectedCharacter = characters[characterChoice]; //character is selected based on which button the player picked (such as 0) //then gets the index character of the array (spot 0 in that case)
        for (int i = 0; i < cooldownButtons.Length; i++) //loops through the array until all have been initialzed
        { //*IMPORTANT* If there are too many abilities, then some will get ignored because there are too many abilities //too few abilities will create blank buttons //need to account for this
            try //set up just in case there are too many abilities or ability icons and an error is thrown
            {
                cooldownButtons[i].Initialize(selectedCharacter.characterAbilities[i], weaponMarker.gameObject); //each character has an array of character abilities //the selected ability is the one in character abilities spot i //the weapon holder is the first object that was found that had a weapon marker
            }
            catch
            {
                //pass because abilities or ability icons are out of range
            }
        }
    }

    public void StartHidePlayerTimer()
    {
        StartCoroutine(HidePlayerTimer());
    }

    public IEnumerator HidePlayerTimer() //set up so that the player doesn't spawn right before the level swap //made public so it can be activated outside this specific script
    {
        yield return new WaitForSeconds(loadNewScene.GetSwapLevelTime()); //needs to be slightly longer than SwapLevelTimer()'s counter so the player doesn't appear before the level swap is complete
        GetCharacterObject().SetActive(true);
    }

    public GameObject GetCharacterObject()
    {
        return spawnedPlayer;
    }

    public bool GetCharacterActive() //used to check if the character is active
    {
        return characterActive;
    }

    public void SetCharacterActive(bool status)
    {
        characterActive = status;
    }

    public void TurnOffCanvas() //when called, ensures that all HUD elements are set to inactive/turned off
    {
        UICanvas.gameObject.SetActive(false);
    }
}
