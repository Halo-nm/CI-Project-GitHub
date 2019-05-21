using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    GameObject newArrow;

    // Start is called before the first frame update
    // Update is called once per frame

    public void Shoot()
    {
        //firePoint.rotation = Quaternion.Euler(10, 10, 10);
        newArrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Destroy(newArrow, 3.0f); //in case the instantiated arrow prefab doesn't make contact with another object and destroy itself in the projectile script
    }

    public Transform GetFirePoint()
    {
        return firePoint;
    }
}
