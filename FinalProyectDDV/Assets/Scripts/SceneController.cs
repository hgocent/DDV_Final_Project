using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.getPortalState()==true)
        {
            //Debug.Log("Portal extra level has been opened");
            
            if (SceneManager.GetActiveScene().name == "Nivel_1")//if (gameObject.tag == "PlayerL1")
            {
                GameObject.Find("Player").transform.position = new Vector3(-31.97f, 0.66f, -2.19f);
                
                GameManager.setPortalState(false);
                //Debug.Log("Player de nivel 1");
            }
            //
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(other.tag);
        if (other.tag=="PlayerL1")
        {
            SceneManager.LoadScene(1);
        }
        else if (other.tag=="PlayerL1a")
        {
            SceneManager.LoadScene(0);
        }

        
    }
}
