using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile-neel : MonoBehaviour {
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update(){

    if (Input.GetKeyDown(KeyCode.RightArrow)) {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow)) {
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow)) {

        }
    }
}
