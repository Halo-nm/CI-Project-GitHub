using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrippleTrap : MonoBehaviour
{
    [SerializeField] GameObject damageBurst;
    [SerializeField] bool destroyOnHit = true;
    [SerializeField] bool currentlySlowed = false;
    [SerializeField] bool hurtPlayer = false;

    private int damageToDeal = 5;
    private float speedDivisor = 2f;
    private float slowedDuration = 3f;

    private float moveSpeed;
    private float storeMoveSpeed;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && !currentlySlowed)
        {
            currentlySlowed = true; //used to ensure the same enemy cannot be hurt/slowed again
            moveSpeed = collider.gameObject.GetComponentInParent<StandardEnemyController>().GetMoveSpeed();
            storeMoveSpeed = moveSpeed; //enemy's move speed is stored for use later before it is altered
            StartCoroutine(SlowedTimer(collider));
            collider.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToDeal); //hurts the enemy
            GameObject tempBurst = Instantiate(damageBurst, collider.transform.position, collider.transform.rotation); //causes a blood burst
            Destroy(tempBurst, 1.0f);
        }
        if (collider.gameObject.tag == "Player" && hurtPlayer)
        {
            currentlySlowed = true;
            moveSpeed = collider.gameObject.GetComponentInParent<StandardEnemyController>().GetMoveSpeed();
            storeMoveSpeed = moveSpeed; //enemy's move speed is stored for use later before it is altered
            StartCoroutine(SlowedTimer(collider));
            collider.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToDeal); //hurts the enemy
            GameObject tempBurst = Instantiate(damageBurst, collider.transform.position, collider.transform.rotation); //causes a blood burst
            Destroy(tempBurst, 1.0f);
        }
    }

    IEnumerator SlowedTimer(Collider2D collider) //passing in the enemy as a parameter
    {
        collider.gameObject.GetComponentInParent<StandardEnemyController>().SetMoveSpeed(moveSpeed / speedDivisor); //enemy's move speed is divided by the speed divisor
        yield return new WaitForSeconds(3);
        currentlySlowed = false;
        moveSpeed = storeMoveSpeed; //move speed is returned to its former value
        if (collider != null)
        {
            collider.gameObject.GetComponentInParent<StandardEnemyController>().SetMoveSpeed(moveSpeed); //enemy's move speed is returned to its former speed
        }

        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }

    public int GetDamageToDeal()
    {
        return damageToDeal;
    }

    public void SetDamageToDeal(int damage)
    {
        damageToDeal = damage;
    }

    public float GetSpeedDivisor()
    {
        return speedDivisor;
    }

    public void SetSpeedDivisor(float divisor)
    {
        speedDivisor = divisor;
    }

    public float GetSlowedDuration()
    {
        return slowedDuration;
    }

    public void SetSlowedDuration(float duration)
    {
        slowedDuration = duration;
    }
}
