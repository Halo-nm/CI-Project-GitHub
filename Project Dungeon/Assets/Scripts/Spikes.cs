using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] float spikePulsationSpeed = 0.01f; //the smaller the number, the longer the spike is down for the player
    public float currentTime = 0f;
    public bool spike;

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
        else if (currentTime > spikePulsationSpeed) 
        {
            boxCollider2D.enabled = true;
            spike = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (spike == true)
        {
            if (other.gameObject.name == "Player" || other.gameObject.name == "Player(Clone)")
            {
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
            }
        }
    }
} 
 