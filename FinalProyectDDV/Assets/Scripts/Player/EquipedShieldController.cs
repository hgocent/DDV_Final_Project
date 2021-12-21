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
        extraLvlEvents.mgWonEvent += ActivateEquipedShield; // suscripcion a minigame won (para activar el equiped shield del player)

        playerShield = GameObject.Find("/Player/Shield");
        //Debug.Log(GameManager.isMiniGameWon);

        if (GameManager.isMiniGameWon == false || (GameManager.isMiniGameWon == true && GameManager.getShieldMeter() <= 0) )
        //if (GameManager.isMiniGameWon == false)
        {
            playerShield.SetActive(false); //deactivate equiped shield if minigame is not won yet
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActivateEquipedShield()
    {
        if (GameManager.getShieldMeter() > 0)
        {   
            playerShield.SetActive(true);
        }

    }
}


//GameObject.Find("/Player/Shield").SetActive(true); //activate player shield (equiped shield)