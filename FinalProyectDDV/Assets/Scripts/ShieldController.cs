using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShieldController : MonoBehaviour
{   
    [SerializeField] private GameObject shield;
    private GameObject sBar;
    

    private void Start() 
    {
       sBar = GameObject.Find("/HUD/Canvas/Panel/ShieldBar"); //New
       extraLvlEvents.mgWonEvent += ActivateShield;

    }
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) 
    {
        
     //Debug.Log(other.tag.Substring(0, 6));
      if (other.tag.Substring(0, 6) == "Player")
      {
          //shield.SetActive(false);
          sBar.SetActive(true);
          extraLvlEvents.mgWonEvent -= ActivateShield;          
          Destroy(gameObject);
      }  
    } 

    private void ActivateShield()
    {
        shield.SetActive(true);
    }
}
