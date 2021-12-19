using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;


public class MiniGame : MonoBehaviour
{
    private bool button = false; //to activate colouring
    private float timerCountDown = 1.5f; //timer reset if 3 colors don't match
    private float rndSwitch; //to select random color between 3 possible colors
    private bool c1 = false; //to check cylinder is coloured or not
    private bool c2 = false;
    private bool c3 = false;
    private int colCheck = 1; //to check color codes, must be initiated in 1 because 1 is neutral for multiplication, otherwise will be taken as 0 and will not check at all.
    [SerializeField] private UnityEvent OnSwitchLight;

    // Start is called before the first frame update

    //private CuboController cuboScript;
    void Start()
    {
        //Debug.Log(GameManager.isMiniGameWon);
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log(timerCountDown);
        if (button == true)
        {   
            //Debug.Log(colCheck);
            
            if (c1 == false)
            {
                c1 = true;
                ChangeColor(1);
            }
            else if(c2 == false)
            {
                c2 = true;
                ChangeColor(2);
            }
            else if(c3 == false)
            {
                c3 = true;
                ChangeColor(3);
            }

            button = false;
        }

        if(c3 == true)
        {
            timerCountDown -= Time.deltaTime;
        }

        //if (colCheck > 1)
        if ((colCheck == 8 || colCheck == 27 || colCheck == 64) && c3 == true) 
        {   
            GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("YOU WON! A portal has opened");
            colCheck = 1;

            GameObject.Find("PortalGreenIdle").transform.position = new Vector3(11, 6, 24);
            GameManager.setPortalState(true);
            
            if (extraLvlEvents.mgWonEvent != null)
            {
              extraLvlEvents.mgWonEvent();  
            }
            
            //Debug.Log(GameManager.isMiniGameWon);

            if (GameManager.isMiniGameWon == false)
            {
                GameManager.isMiniGameWon = true; //New
            }

            //Debug.Log(GameManager.isMiniGameWon);


            timerCountDown = 1.5f;
            

            //won event
            if (extraLvlEvents.mgWonEvent != null)
            {
              extraLvlEvents.mgWonEvent();  
            }
            
            gameObject.SetActive(false); /////////////////////
            
        }
        
        if ((colCheck != 8 || colCheck != 27 || colCheck != 64) && (timerCountDown <= 0))
        {
            c1 = false;
            c2 = false;
            c3 = false;

            colCheck = 1;
            timerCountDown = 1.5f;

            GameObject.Find("Cylinder (1)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            GameObject.Find("Cylinder (2)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            GameObject.Find("Cylinder (3)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        } 

        //

    }

    void ChangeColor(int c)
    {  
        rndSwitch = UnityEngine.Random.Range(2, 4); //Random.Range(2, 5) to get random number 2, 3 or 4
        colCheck *= (int)rndSwitch;

        
        switch(rndSwitch)
        {
            case 2:
            GameObject.Find("Cylinder ("+ c +")").GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            break;
            
            case 3:
            GameObject.Find("Cylinder ("+ c +")").GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            break;
            
            case 4:
            GameObject.Find("Cylinder ("+ c +")").GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            break;
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        button = true;
        OnSwitchLight?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        button = false;
    }

    void OnCollisionEnter(Collision col)
    {
        button = true;
    } 
    void OnCollisionExit(Collision col)
    {
        button = false;
    } 


}

public static class extraLvlEvents
{
    public static Action mgWonEvent;
}

