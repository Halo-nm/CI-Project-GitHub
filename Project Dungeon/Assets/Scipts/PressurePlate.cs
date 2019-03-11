using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] float triggerWaitTime = 1; //in seconds
    float timeSinceLastTrigger;

    [SerializeField] GameObject objectToDespawn;

    [SerializeField] bool spawnObject = false; //set to true if an object should be spawned on trigger
    [SerializeField] GameObject objectPrefabToSpawn;
    [SerializeField] float objectMoveSpeed = 1.0f;
    [SerializeField] Transform startMarker;
    [SerializeField] Transform endMarker;
    private float startTime;
    private float journeyLength;
    private float fracJourney;

    private void Start()
    {
        startTime = Time.time;
        //journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;

        float distanceCovered = (Time.time - startTime) * objectMoveSpeed;
        float fracJourney = distanceCovered / journeyLength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (timeSinceLastTrigger >= triggerWaitTime)
            {
                if (spawnObject)
                {
                    //Rigidbody2D objectInstance; nope
                    //Instantiate(objectPrefabToSpawn, startMarker.position, startMarker.rotation);
                    //objectPrefabToSpawn.transform.position = Vector3.Lerp(startMarker.transform.position, startMarker.transform.position, fracJourney);
                    //objectInstance.AddForce(spawnLocation.forward * 50); nope
                }
                else
                {
                    Destroy(objectToDespawn);
                }
                timeSinceLastTrigger = 0;
            }
        }
    }





}
