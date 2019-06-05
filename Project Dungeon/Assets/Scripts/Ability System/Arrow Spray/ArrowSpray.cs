using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpray : MonoBehaviour
{
    [HideInInspector] public GameObject arrowPrefab;
    [HideInInspector] public int damagePerArrow = 5;
    [HideInInspector] public float arrowSpeed = 25f;
    [HideInInspector] public float degreeBetweenSplit = 30f;

    private bool playerAbility;
    private float abilityTime = 0.3f; //hard coded for now
    private float abilityTimeCounter;
    private bool playerFound = false;

    private Rigidbody2D myRigidbody;
    private Transform firePoint;
    private Transform firePoint2;
    private Transform firePoint3;

    Arrow arrow;
    Projectile projectile;
    CharacterSelector characterSelector;
    PlayerController playerController;
    Animator animator;

    public void Setup()
    {
        arrow = FindObjectOfType<Arrow>();
        projectile = FindObjectOfType<Projectile>();
    }

    public void Update()
    {
        if (playerFound)
        {
            if (abilityTimeCounter > 0) //set up instead of using coroutines becauses of previous code (consider using coroutine instead)
            {
                abilityTimeCounter -= Time.deltaTime; //ticks the timer down over time
            }

            if (abilityTimeCounter <= 0)
            {
                playerAbility = false;
                animator.SetBool("Ability", false);
            }
        }
    }

    public void PerformArrowSpray() //called when the player calls the ability
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        playerController = characterSelector.GetCharacterObject().GetComponent<PlayerController>();
        projectile = arrowPrefab.GetComponent<Projectile>();
        animator = characterSelector.GetCharacterObject().GetComponent<Animator>();

        playerFound = true;

        int storeDamageToDeal = projectile.GetDamageToDeal(); //stores the initial damage of the arrows prior to the change
        projectile.SetDamageToDeal(damagePerArrow); //changes the damage of the arrows temporarily

        firePoint = arrow.GetFirePoint();
        firePoint2 = arrow.GetFirePoint();
        firePoint3 = arrow.GetFirePoint();

        myRigidbody = arrowPrefab.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = Vector2.zero; //prevents the player from sliding while attacking (stops the player)

        abilityTimeCounter = abilityTime;
        playerAbility = true;
        animator.SetBool("Ability", true);

        CheckLastMove(1); //checks the direction of the player for the first arrow
        GameObject newArrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation); //fires the first arrow
        CheckLastMove(2);
        GameObject newArrow2 = Instantiate(arrowPrefab, firePoint2.position, firePoint2.rotation);
        CheckLastMove(3);
        GameObject newArrow3 = Instantiate(arrowPrefab, firePoint3.position, firePoint3.rotation);
        Destroy(newArrow, 5f); //set just in case the arrow doesn't collide with anything
        Destroy(newArrow2, 5f);
        Destroy(newArrow3, 5f);

        projectile.SetDamageToDeal(storeDamageToDeal); //set the arrow damage back to what it was set to before
    }

    private void CheckLastMove(int firePointNum) //checks the player's last move position in order to change the angle of the to-be-fired arrow
    {
        Vector2 lastMove = playerController.GetLastMove();

        if (lastMove.x == 1 && lastMove.y == 0)
        {
            if (firePointNum == 1)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 270 - degreeBetweenSplit);
            }
            else if (firePointNum == 2)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 270);
            }
            else if (firePointNum == 3)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 270 + degreeBetweenSplit);
            }
        }
        else if (lastMove.x == -1 && lastMove.y == 0)
        {
            if (firePointNum == 1)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 90 - degreeBetweenSplit);
            }
            else if (firePointNum == 2)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 90);
            }
            else if (firePointNum == 3)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 90 + degreeBetweenSplit);
            }
        }
        else if (lastMove.x == 0 && lastMove.y == 1)
        {
            if (firePointNum == 1)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 0 - degreeBetweenSplit);
            }
            else if (firePointNum == 2)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 0);
            }
            else if (firePointNum == 3)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 0 + degreeBetweenSplit);
            }
        }
        else if (lastMove.x == 0 && lastMove.y == -1)
        {
            if (firePointNum == 1)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 180 - degreeBetweenSplit);
            }
            else if (firePointNum == 2)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 180);
            }
            else if (firePointNum == 3)
            {
                firePoint.rotation = Quaternion.Euler(playerController.GetLastMove().x, playerController.GetLastMove().y, 180 + degreeBetweenSplit);
            }
        }
    }
}