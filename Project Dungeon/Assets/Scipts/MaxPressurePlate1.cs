using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxPressurePlate1 : MonoBehaviour
{
    //[SerializeField] float triggerWaitTime = 1; //in seconds
    //float timeSinceLastTrigger;

    [SerializeField] Spike SpikeToChange;
    [SerializeField] Spike SpikeToChange2;

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
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player(Clone)")
        {
            SpikeToChange.Active = !SpikeToChange.Active;
            SpikeToChange2.Active = !SpikeToChange2.Active;
        }
    }
}
