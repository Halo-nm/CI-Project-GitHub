using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] GameObject damageBurst;
    [SerializeField] Transform hitPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToDeal);
            GameObject tempBurst = Instantiate(damageBurst, other.transform.position, other.transform.rotation);
            Object.Destroy(tempBurst, 1.0f);
        }
    }
}
