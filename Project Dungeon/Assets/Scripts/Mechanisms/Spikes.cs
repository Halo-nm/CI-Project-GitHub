using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] float currentTime = 0f;
    [SerializeField] bool spike;

    public bool hurtEnemy = false;

    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        if ((currentTime >= 0) && (currentTime < 1))
        {
            spike = false;
        }
        else if (currentTime >= 2)
        {
            boxCollider2D.enabled = false;
            currentTime = 0;
        }
        else if (currentTime > 1) 
        {
            boxCollider2D.enabled = true;
            spike = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (spike == true)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
            }
            if (other.gameObject.tag == "Enemy (Base)" && hurtEnemy) //only reading the first tag the pops up, so the base (core) portion of the enemy is tagged as "Enemy (Base)" so that the spike collision can find the component in its (damage, health, etc...) child
            {
                other.gameObject.GetComponentInChildren<EnemyHealthManager>().HurtEnemy(damageToDeal);
            }
        }
    }
} 
 