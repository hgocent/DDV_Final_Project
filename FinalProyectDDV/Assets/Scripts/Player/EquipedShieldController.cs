using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

public class EquipedShieldController : MonoBehaviour
{
    private GameObject playerShield;

    // Start is called before the first frame update
    void Start()
    {

        playerShield = GameObject.Find("/Player/Shield");
        //Debug.Log(GameManager.isMiniGameWon);
   
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isMiniGameWon == false || (GameManager.isMiniGameWon == true && GameManager.getShieldMeter() <= 0))
        {
            playerShield.SetActive(false); //deactivate equiped shield if minigame is not won yet
        }
        else if (GameManager.isMiniGameWon == true && GameManager.getShieldMeter() > 0) 
        {    
            playerShield.SetActive(true);
        }

    }

}
