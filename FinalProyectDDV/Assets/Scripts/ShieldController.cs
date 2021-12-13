using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShieldController : MonoBehaviour
{   
    [SerializeField] private GameObject shield; // 
    private GameObject sBar;
    
    private String miniGameState = "notplayed";
    private void Awake() 
    {   
        
    }
    private void Start() 
    {
        
        //if(GameObject.Find("/HUD/Canvas/Panel/ShieldBar") != null)
        {
            sBar = GameObject.Find("/HUD/Canvas/Panel/ShieldBar"); //New

        }
        
        extraLvlEvents.mgWonEvent += ActivateShield;
        
        Debug.Log(shield + " - " + sBar);
    }
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) 
    {
        
     //Debug.Log(other.tag.Substring(0, 6));
      if ((other.tag.Substring(0, 6) == "Player") && (miniGameState == "won"))
      {
          //shield.SetActive(false);
          sBar.SetActive(true);
          extraLvlEvents.mgWonEvent -= ActivateShield;

          //Destroy(gameObject); //shield
          shield.SetActive(false);
      }  
    } 

    private void ActivateShield()
    {
        //if (shield != null)
        {
            miniGameState = "won";
            shield.SetActive(true);
        }
    }
}
