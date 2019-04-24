using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //needed to access members of the UI namespace, such as "Image" and "Text"

public class AbilityCooldown : MonoBehaviour
{
    public string abilityButtonAxisName = "1"; //what button is going to be triggering the ability from the input manager
    public Image darkMask;
    public Text cooldownTextDisplay;

    private Ability ability;
    private GameObject weaponHolder; //what holds the ability scripts to get a reference to the scripts from here (maybe Player?)
    private Image myButtonImage;
    private AudioSource abilityAudioSource; //the clip gets set by the scriptable object further down the script
    private float cooldownDuration; //how long the cooldown takes //set from the base cooldown in "Ability"
    private float nextReadyTime; //the next time (in seconds) that the object comes off of cooldown
    private float cooldownTimeLeft; //time left (only displayed in the UI)

    void Update()
    {
        bool cooldownComplete = (Time.time > nextReadyTime); //if more time has elapsed than nextReadyTime, then cooldownComplete is true
        if (cooldownComplete) //if the cooldown is complete, the ability is ready
        {
            AbilityReady(); 
            if(Input.GetButtonDown(abilityButtonAxisName)) //checks if the ability button specified by abilityButtonAxisName is pressed
            {
                ButtonTriggered(); //time to trigger the ability
            }
        }
        else //decrement cooldown if the cooldown is not complete
        {
            Cooldown();
        }

    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder) //temp
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>(); //get a component reference to the Image component (that will display the icon)
        abilityAudioSource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.abilitySprite; //"ability" is the scriptable object //sets the sprite of the UI element to the sprite stored in the scriptable object
        darkMask.sprite = ability.abilitySprite; //set to the same thing so the mask matches the icon
        cooldownDuration = ability.abilityBaseCooldown;
        ability.Initialize(weaponHolder); //called from the "PracticeAbility" script //gets the component references and sets all the values in the scripts down the chain
        AbilityReady(); //called since the first time the ability is initialized, it will be ready to be used
    }

    private void AbilityReady() //called every time the ability is ready
    {
        cooldownTextDisplay.enabled = false; //when the ability is ready to use, the cooldown text and mask are turned off
        darkMask.enabled = false;
    }

    private void Cooldown() //called every frame when on cooldown //called ultimately from Update()
    {
        cooldownTimeLeft -= Time.deltaTime; //subtracting the time taken to render the last frame from the total cooldown time left
        float roundedCooldown = Mathf.Round(cooldownTimeLeft); //don't want long decimals in the UI
        cooldownTextDisplay.text = roundedCooldown.ToString();
        darkMask.fillAmount = cooldownTimeLeft / cooldownDuration; //give a number between 0 and 1, which is the % of cooldown duration that has elapsed
    }

    private void ButtonTriggered() //stuff to do once the player has pressed the activation button
    {
        nextReadyTime = cooldownDuration + Time.time; //next time allowed to activate
        cooldownTimeLeft = cooldownDuration;
        cooldownTextDisplay.enabled = true;
        darkMask.enabled = true;
        abilityAudioSource.clip = ability.abilitySound; //set the audio source clip to the sound clip that is stored in the scriptable object
        abilityAudioSource.Play(); //sound clip is played
        ability.TriggerAbility(); //called from PracticeAbility (the ability standards script that's derived from Ability)
    }
}
