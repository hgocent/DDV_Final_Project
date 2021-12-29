using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TimerCountdown : MonoBehaviour
{   
    private Text CountdownText;
    private int minutesLeft = 1;
    private int secondsLeft = 30;

    private bool TakeAway = false;

    private bool triggered = false;

    private GameObject gameOverPanel;
    [SerializeField] private GameObject CountDownMsg;

    // Start is called before the first frame update
    void Start()
    {
        CountdownText = GameObject.Find("/Canvas/CountDown").GetComponent<Text>();
        gameOverPanel = GameObject.Find("/Canvas/Panel/GameOverPanel");

        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true && TakeAway == false && minutesLeft >= 0)
        {
            StartCoroutine(TimeTaker());
        }

        if (minutesLeft < 0)
        {
           Debug.Log("Game Over");
           gameOverPanel.SetActive(true);
        }
    }

    IEnumerator TimeTaker()
    {
        TakeAway = true;

        yield return new WaitForSeconds(1);

        //secondsLeft -= 1;

        if (secondsLeft == 0)
        {
            secondsLeft = 60;
            minutesLeft -= 1;
        }

        secondsLeft -= 1;
        
        if(minutesLeft >= 0) CountdownText.text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");

        TakeAway = false;
    }

    public void OnTriggerEnter(Collider other) 
    {    
       if (triggered == false)
       {
           triggered = true;
           Invoke("TurnOnMessage", 1f);
           Invoke("TurnOffMessage", 10f);
       }
       
    }

     void TurnOnMessage()
   {
       CountDownMsg.SetActive(true);
   }
   void TurnOffMessage()
   {
       CountDownMsg.SetActive(false);
   }

   
}
