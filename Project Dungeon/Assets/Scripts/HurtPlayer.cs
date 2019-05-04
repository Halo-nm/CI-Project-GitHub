using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] int damageToDeal;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Player(Clone)")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
        }
    }
}