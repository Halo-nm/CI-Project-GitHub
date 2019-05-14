using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandardEnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float timeBetweenMove = 2f;
    [SerializeField] float timeToMove = 1f;
    [SerializeField] bool moveRandomly = true; //gives the option for the enemy to randomly move when out of the player's pursuit range
    [SerializeField] bool followOnceSeen = true;

    private Transform target; //the target that the enemy is trying to pursue (the player)

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
        if (moveRandomly && target == null) //if the enemy is supposed to randomly move and doesn't have the player in its sights
        {
            if (isMoving)
            {
                timeToMoveCounter -= Time.deltaTime;
                if (target == null)
                {
                    myRigidBody.velocity = moveDirection; //randomly moves if the enemy doesn't have a target
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //moves towards the player otherwise
                }

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
        else
        {
            if (target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //moves towards the player otherwise
                myRigidBody.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform; //if within the collider trigger range, the enemy's target is the player
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !followOnceSeen)
        {
            target = null; //if the player leaves the collider trigger range, the enemy will stop pursing the player
        }
    }
}
