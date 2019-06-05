using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    [SerializeField] Vector2 startDirection;

    CharacterSelector characterSelector;
    PlayerController playerController;
    LoadNewScene loadNewScene;

    private bool startPosSet = false;

    void Start()
    {
        loadNewScene = FindObjectOfType<LoadNewScene>();
    }

    void Update()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();

        if (characterSelector != null)
        {
            if (characterSelector.GetCharacterActive()) //checks if the character is active
            {
                playerController = characterSelector.GetCharacterObject().GetComponent<PlayerController>(); //gets the current player instance's health manager

                if (!startPosSet)
                {
                    startPosSet = true;
                    playerController.transform.position = transform.position; //setting the player's position to the same position as the start point
                    playerController.lastMove = startDirection; //The Vector2 variable, lastMove, in the PlayerController script was made public so it could be updated here
                }
            }
        }
    }

    public Vector2 GetStartPosition()
    {
        return new Vector2(transform.position.x, transform.position.y); //returns the x and y values of the player start point object
    }
}
