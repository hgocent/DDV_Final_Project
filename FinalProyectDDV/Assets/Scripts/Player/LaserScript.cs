using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private float laserTime = 5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserTime -= Time.deltaTime;
        if (laserTime < 0)
        {
            Destroy(gameObject);
            laserTime = 5f;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy" || other.tag == "Enviroment")
        {
            Destroy(gameObject);
        }
    }
}
