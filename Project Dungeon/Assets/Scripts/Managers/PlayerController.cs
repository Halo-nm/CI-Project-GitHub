using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator animator;
    public Rigidbody2D myRigidbody;

    public Vector2 lastMove; //Use Vector 2 for (x,y); not Vector 3 b/c it's (x,y,z)
    private bool playerMoving;

    public float attackTime = 0.5f;
    private float attackTimeCounter;
    private bool playerAttacking;

    private static bool playerExists; //sets the player to true and keeps it true when entering back into the starting scene (this avoids duplicates)

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void FixedUpdate()
    {
        playerMoving = false;

        if (!playerAttacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) //GetAxisRaw takes the input of that very second
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f)); //original movement code, before the rigidbody was implemented
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y); //In this case, Time.deltaTime made the player move a LOT slower
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) //GetAxisRaw takes the input of that very second
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) //prevents the "skating" movement effect
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            attackTimeCounter = attackTime;
            playerAttacking = true;
            myRigidbody.velocity = Vector2.zero; //x and y value of 0
            animator.SetBool("PlayerAttacking", true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime; //ticks the timer down over time
        }

        if (attackTimeCounter <= 0)
        {
            playerAttacking = false;
            animator.SetBool("PlayerAttacking", false);
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal")); //all these animator.Set(s) update the animator variables that were created wit
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
        /*In order to not make the animations take time to activate (i.e. the player starts moving, but is still in the idle animation for a little while),
        click on the transition, uncheck "Has Exit Time," uncheck "Fixed Duration," and set "Transition Duration" to 0. Supposedly, "Transition Duration
        is what causes this the most.*/
    }

    public bool GetPlayerAttacking()
    {
        return playerAttacking;
    }
}