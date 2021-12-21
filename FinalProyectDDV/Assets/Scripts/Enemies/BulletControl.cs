using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private float bulletTime = 3f;
    
    
    
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       bulletTime -= Time.deltaTime;
       if (bulletTime < 0)
       {
           Destroy(gameObject);
           bulletTime = 3f;
       }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerL1" || other.gameObject.tag == "Enviroment")
        {
            Destroy(gameObject);
        }
    }
        
    
}
