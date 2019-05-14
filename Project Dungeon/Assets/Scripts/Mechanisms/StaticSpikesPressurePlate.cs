using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpikesPressurePlate : MonoBehaviour
{
    //[SerializeField] float triggerWaitTime = 1; //in seconds
    //float timeSinceLastTrigger;

    [SerializeField] List<AlternatingSpike> spikes= new List<AlternatingSpike>();
    

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
        if (collision.gameObject.tag == "Player")
        {
            for(int i = 0; i < spikes.Count; i++)
            {
                spikes[i].Active = !spikes[i].Active;
            }
        }
    }
}
