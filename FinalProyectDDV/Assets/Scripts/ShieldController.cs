using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShieldController : MonoBehaviour
{   
   [SerializeField] private GameObject shield;

    private void Start() 
    {
       extraLvlEvents.mgWonEvent += ActivateShield;

    }
    
    // Start is called before the first frame update
    
    /*private void OnTriggerEnter(Collider other) 
    {
     //Debug.Log(other.tag.Substring(0, 6));
      if (other.tag.Substring(0, 6) == "Player")
      {
          shield.SetActive(true);
                   
          Destroy(gameObject);
      }  
    }*/ 

    private void ActivateShield()
    {
        shield.SetActive(true);
    }
}
