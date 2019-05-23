using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public bool newCharacter = false;
    public GameObject followTarget; //can change the target for something like a brief cutscene (to focus on something else)
    public float moveSpeed; //speed of camera movement - Setting to 0 is useful b/c it freezes all camera movement. Could be useful in certain rooms/areas
    private Vector3 targetPos; //position of camera

    private static bool cameraExists;

    CharacterSelector characterSelector;
    PlayerStartPoint playerStartPoint;

    void Start ()
    {
        characterSelector = FindObjectOfType<CharacterSelector>(); //Needed to "properly" access the methods of the CharacterSelector script... for some reason
        playerStartPoint = FindObjectOfType<PlayerStartPoint>();

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	void Update ()
    {
        if (newCharacter)
        {
            followTarget = characterSelector.GetCharacterObject();
        }
        if (characterSelector != null)
        {
            if (characterSelector.GetCharacterActive()) //checks if the character is active
            {
                targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z); //using the z position of the camera
            }
            else
            {
                if (playerStartPoint != null)
                {
                    targetPos = new Vector3(playerStartPoint.GetStartPosition().x, playerStartPoint.GetStartPosition().y, -10);  //sets the camera's default position to the position of the player start point game object to prevent camera drag on character spawn
                }
                else
                {
                    targetPos = new Vector3(0, 0, -10); //if there is no player start point present, default the camera to these values
                }
            }
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime); //current position, new position (target position), amount of movement per frame - Using Time.deltaTime to adjust to computer framerates
    }
}
