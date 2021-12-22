using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShieldController : MonoBehaviour
{   
    [SerializeField] private GameObject shield; // shield before being catched
    private GameObject equipedShield; // shield equipped on player
    private GameObject sBar;

    private void Start() 
    {
        //Debug.Log(GameManager.isMiniGameWon);
        equipedShield = GameObject.Find("/Player/Shield"); 

        sBar = GameObject.Find("/HUD/Canvas/Panel/ShieldBar"); 

        extraLvlEvents.mgWonEvent += ActivateShield;

        if (GameManager.isMiniGameWon == false || GameManager.isMiniGameWon == true && GameManager.getShieldMeter() <= 0)
        {
            equipedShield.SetActive(false);
        }
        
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        
     //Debug.Log(other.tag.Substring(0, 6));
      if ((other.tag.Substring(0, 6) == "Player") && (GameManager.isMiniGameWon == true))
      {
        
        sBar.SetActive(true);
        extraLvlEvents.mgWonEvent -= ActivateShield;

        //Destroy(gameObject); //shield on the floor
        shield.SetActive(false);
        equipedShield.SetActive(true); // equipped shield on player
      }  
    }
    

    private void ActivateShield() //activate shield bar on HUD
    {
        if (GameManager.isMiniGameWon == false)
        {
            shield.SetActive(true);
            //extraLvlEvents.mgWonEvent -= ActivateShield;
        }
    }
}
