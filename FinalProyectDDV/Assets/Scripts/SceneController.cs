using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.getExtraLevelGreenPortalState() == true)
        {
            //Debug.Log("Portal extra level has been opened");
            
            if (SceneManager.GetActiveScene().name == "Nivel_1")//if (gameObject.tag == "PlayerL1")
            {
                GameObject.Find("Player").transform.position = new Vector3(-10.5f,6.57000017f,-79f);
                
                GameManager.setExtraLevelGreenPortalState(false);

            }/*else if (SceneManager.GetActiveScene().name == "Extralvl_1")
            {
                GameObject.Find("Player").transform.position = new Vector3(-40f, 1f, 18);
            }*/
            //
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(gameObject.name);
        
        switch (gameObject.name)
        {
            case "PortalExtraLevel":
                if (SceneManager.GetActiveScene().name == "Nivel_1")
                {
                    SceneManager.LoadScene("Extralvl_1");

                }else if (SceneManager.GetActiveScene().name == "Extralvl_1")
                {
                    SceneManager.LoadScene("Nivel_1");
                }
            break;

            case "PortaltoLevel2":
                SceneManager.LoadScene("Nivel_2");
            break;

            case "a":
                
            break;
            
            case "b":
                
            break;
            
            case "c":
               
            break;
            
            default:
                //print ("Incorrect");
            break;
        }



        /*if (other.tag=="PlayerL1")
        {
            SceneManager.LoadScene("Extralvl_1");
        }
        else if (other.tag=="PlayerL1a")
        {
            SceneManager.LoadScene("Nivel_1");
        }*/
        
        
        
    }
}
