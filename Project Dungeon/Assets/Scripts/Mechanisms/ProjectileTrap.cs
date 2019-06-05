using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrap : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int damageToDeal;
    [SerializeField] float timeBetweenShots = 3f;

    private float currentTime = 0f;
    private bool projectileReady;

    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        if ((currentTime >= 0) && (currentTime < 1))
        {
            if (projectileReady == true)
            {
                GameObject newArrow = Instantiate(projectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(newArrow, 5f);
            }
            projectileReady = false;
        }
        else if (currentTime >= timeBetweenShots)
        {
            currentTime = 0;
        }
        else if (currentTime > 1)
        {
            projectileReady = true;
        }
    }   
}
