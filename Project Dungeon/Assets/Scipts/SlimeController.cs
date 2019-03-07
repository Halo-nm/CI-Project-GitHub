using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float timeBetweenMove = 2f;
    [SerializeField] float timeToMove = 1f;

    [SerializeField] float waitToReload = 1f;
    private bool isReloading;
    private GameObject thePlayer;

    private Rigidbody2D myRigidBody;

    private float timeBetweenMoveCounter = 0f;
    private float timeToMoveCounter = 0f;
    private bool isMoving;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
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
                //timeBetweenMoveCounter = timeBetweenMove;
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
                //timeToMoveCounter = timeToMove;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false); //deactivates the player; doesn't allow it to be moved
            isReloading = true;
            thePlayer = other.gameObject; //sets thePlayer to the current player in the script
        }
    }
}
