using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HudLabelsController : MonoBehaviour
{
    private GameObject livesText;
    private GameObject deathsText;

    // Start is called before the first frame update
    void Start()
    {
        //soldier_events.OnEnemyDeath += updateDeathLabel;
        //player_events.OnPlayerDeath += updateLivesLabel;

        livesText = GameObject.Find("/HUD/Canvas/Panel/LivesText");
        livesText.GetComponent<Text>().text = GameManager.getLives().ToString(); //set value on HUD
        
        deathsText = GameObject.Find("/HUD/Canvas/Panel/DeathText");

        

    }

    IEnumerator waiter(float x)
    {
        //Wait for xx seconds
        yield return new WaitForSeconds(x);

    }
    private void updateLivesLabel()
    {
        
        //livesText.GetComponent<Text>().text = GameManager.getLives().ToString(); //set value on HUD
        
    }

    private void updateDeathLabel()
    {
        //deathsText.GetComponent<Text>().text = GameManager.getEnemyDeathCount().ToString(); //set value on HUD
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Mis vidas: " + GameManager.getLives().ToString());
        livesText.GetComponent<Text>().text = GameManager.getLives().ToString(); //set value on HUD

        //Debug.Log("Enemies Count: " + GameManager.getEnemyDeathCount().ToString());
        deathsText.GetComponent<Text>().text = GameManager.getEnemyDeathCount().ToString(); //set value on HUD
        
        StartCoroutine(waiter(1));
    }
}
