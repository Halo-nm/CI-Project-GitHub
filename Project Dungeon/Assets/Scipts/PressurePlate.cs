using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //[SerializeField] float triggerWaitTime = 1; //in seconds
    //float timeSinceLastTrigger;

    [SerializeField] GameObject objectToDespawn;

    //[SerializeField] bool spawnObject = false; //set to true if an object should be spawned on trigger
    //[SerializeField] GameObject objectPrefabToSpawn;
    //[SerializeField] float objectMoveSpeed = 1.0f;
    //[SerializeField] Transform startMarker;
    //[SerializeField] Transform endMarker;

    void Update()
    {
        //timeSinceLastTrigger += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //if (timeSinceLastTrigger >= triggerWaitTime)
            //{
                //if (spawnObject)
                //{
                    //Rigidbody2D tempObject = Instantiate(objectPrefabToSpawn, startMarker.position, objectPrefabToSpawn.transform.rotation);
                    //tempObject.velocity = startMarker.TransformDirection(Vector3.forward * 20);
                //}
                //else
                //{
                    //Destroy(objectToDespawn);
                //}
                //timeSinceLastTrigger = 0;
            //}
            Destroy(objectToDespawn);
        }
    }
}
