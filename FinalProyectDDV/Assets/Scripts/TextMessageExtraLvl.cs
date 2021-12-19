using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextMessageExtraLvl : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        //Debug.Log("I triggered with: " + other.gameObject.tag);
        if (other.gameObject.tag == "PlayerL1a" && GameManager.isMiniGameWon != true)
        {
            GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("Match a color");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerL1a")
        {
            GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("");

        }
    }

}

