using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSam : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = transform.up * speed;
    }

    private void OnTriggerStay2D(Collider2D collider) //unsure if Stay or Enter worked better, but Stay certainly works
    {
        if (collider.gameObject.tag != "Ignore" && collider.gameObject.tag != "Player" && collider.gameObject.tag != "Enemy (Base)")
        {
            if (collider.gameObject.tag == "Enemy") //if the projectile makes contact with an enemy, destroy it after a small time //destroying it immediately will prevent any damage from registering
            {
                Destroy(gameObject, 0.05f);
                try //temporarily using a try, catch just in case the specific enemy uses a different controller
                {
                    collider.GetComponentInParent<StandardEnemyController>().SetTarget(); //sets the player as the target once the enemy is hit //the enemy controller is in the parent object
                    collider.GetComponentInParent<StandardEnemyController>().SetFollowOnceSeen(); //sets the enemy to follow the player
                }
                catch
                {
                    //pass
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
