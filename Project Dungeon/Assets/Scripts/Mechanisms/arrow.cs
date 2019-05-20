using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject arrowPrefab;

    // Start is called before the first frame update
    // Update is called once per frame

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);
        Object.Destroy(newArrow, 3.0f); //in case the instantiated arrow prefab doesn't make contact with another object and destroy itself in the projectile script
    }
}
