using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float timeBetweenMove = 2f;
    [SerializeField] float timeToMove = 1f;

    public bool oneHit; //DELETE THIS AFTER PROTOTYPE

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
        if (isReloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                thePlayer.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) //REMOVE AFTER SHOWING PROTOTYPE AND ADD HURTPLAYER SCRIPT BACK ON ENEMIES
    {
        if (oneHit && other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false);
            isReloading = true;
            thePlayer = other.gameObject;
        }
    }
}
