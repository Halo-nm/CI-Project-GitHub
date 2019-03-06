using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    [SerializeField] Vector2 startDirection;

    private PlayerController thePlayer; //has the script attached to it; same below
    private CameraController theCamera;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>(); //Searches the current game world and finds an object that has this script type attached to it (the player, in this case)
        thePlayer.transform.position = transform.position; //setting the player's position to the same position as the start point
        thePlayer.lastMove = startDirection; //The Vector2 variable, lastMove, in the PlayerController script was made public so it could be updated here
        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z); //different than the player position, beause we don't want to change the Z
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
