using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    GameObject newArrow;

    public void Shoot()
    {
        newArrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        newArrow.GetComponent<Projectile>().test();
        Destroy(newArrow, 3.0f); //in case the instantiated arrow prefab doesn't make contact with another object and destroy itself in the projectile script
    }

    public Transform GetFirePoint()
    {
        return firePoint;
    }
}
