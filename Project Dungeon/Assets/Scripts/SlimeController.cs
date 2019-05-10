using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float timeBetweenMove = 2f;
    [SerializeField] float timeToMove = 1f;

    private Transform target; //the target that the enemy is trying to pursue (the player)

    [SerializeField] float waitToReload = 1f;
    private bool isReloading;
    private GameObject thePlayer;

    private Rigidbody2D myRigidBody;

    private float timeBetweenMoveCounter = 0f;
    private float timeToMoveCounter = 0f;
    private bool isMoving;
    private Vector3 moveDirection;

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //the target that the enemy will pursue is the object tagged "Player"

        myRigidBody = GetComponent<Rigidbody2D>();
        isMoving = false;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;
            if (timeToMoveCounter < 0f)
            {
                isMoving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero; //a Vector2 with a "0" on all axis
            if (timeBetweenMoveCounter < 0f)
            {
                isMoving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other) //need to FINISH AND TEST
    {
        if (other.tag == "Player") target = other.transform; //if within the collider trigger range, the enemy's target is the player
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") target = null; //if the player leaves the collider trigger range, the enemy will stop pursing the player
    }
}
