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

        Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);
    }
}
