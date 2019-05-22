using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cripple : MonoBehaviour //make sure to attach to the player!
{
    [HideInInspector] public GameObject crippleTrap;
    [HideInInspector] public int damageToDeal = 5;
    [HideInInspector] public float speedDivisor = 2f;
    [HideInInspector] public float slowedDuration = 3f;
    [HideInInspector] public float maxTrapLifetime = 10f;

    GameObject newCrippleTrap;

    public void Setup()
    {
        //nothing necessary
    }

    public void PerformCripple()
    {
        newCrippleTrap = Instantiate(crippleTrap, gameObject.transform.position, gameObject.transform.rotation); //all the core logic is done in the trap's prefab's script
        try //using a try/catch just in case the object was already triggered, thus already destroying the trap (in CrippleTrap.cs)
        {
            Destroy(newCrippleTrap, maxTrapLifetime);
        }
        catch
        {
            //pass
        }
    }
}