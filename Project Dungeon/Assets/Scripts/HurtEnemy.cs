using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] GameObject damageBurst;
    [SerializeField] Transform hitPoint;

    Siphon siphon;

    private bool successfulHit = false;

    void Start()
    {
        siphon = FindObjectOfType<Siphon>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            if (siphon.GetIsSiphonActive()) //checks if siphon was recently triggered
            {
                successfulHit = true; //the hit was successfully made
            }
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToDeal);
            GameObject tempBurst = Instantiate(damageBurst, other.transform.position, other.transform.rotation);
            Object.Destroy(tempBurst, 1.0f);
        }
    }

    public bool GetSuccessfulHit() //returns whether the hit was successful or not
    {
        return successfulHit;
    }

    public void SetSuccessfulHit() //sets back to false
    {
        successfulHit = false;
    }
}
