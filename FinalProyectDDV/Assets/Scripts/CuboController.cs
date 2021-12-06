using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuboController : MonoBehaviour
{
    [SerializeField] GameObject shield;
    
    
    
    
    private void Start() {
       //extraLvlEvents.ShieldEvent += ActiveShield;
       

    }
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) 
    {
     //Debug.Log(other.tag.Substring(0, 6));
      if (other.tag.Substring(0, 6) == "Player")
      {
          shield.SetActive(true);
                   
          Destroy(gameObject);
      }   
    }

    


}
