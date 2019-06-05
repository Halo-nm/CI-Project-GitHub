using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] GameObject damageBurst;

    private float currentTime = 0f;
    private bool spike;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spike == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (damageBurst != null) //consider centralizing the damage burst spawning (it's in multiple scripts now)
                {
                    GameObject tempBurst = Instantiate(damageBurst, collision.transform.position, collision.transform.rotation);
                    Destroy(tempBurst, 1.0f);
                }
                collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
            }
            if (collision.gameObject.tag == "Enemy (Base)" && hurtEnemy) //only reading the first tag the pops up, so the base (core) portion of the enemy is tagged as "Enemy (Base)" so that the spike collision can find the component in its (damage, health, etc...) child
            {
                if (damageBurst != null) //consider centralizing the damage burst spawning (it's in multiple scripts now)
                {
                    GameObject tempBurst = Instantiate(damageBurst, collision.transform.position, collision.transform.rotation);
                    Destroy(tempBurst, 1.0f);
                }
                collision.gameObject.GetComponentInChildren<EnemyHealthManager>().HurtEnemy(damageToDeal);
            }
        }
    }
} 
 