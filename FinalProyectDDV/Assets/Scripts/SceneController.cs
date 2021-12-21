using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*if (GameManager.isMiniGameWon == false)
        {
            GameObject.Find("/Player/Shield").SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.getPortalState() == true)
        {
            //Debug.Log("Portal extra level has been opened");
            
            if (SceneManager.GetActiveScene().name == "Nivel_1")//if (gameObject.tag == "PlayerL1")
            {
                GameObject.Find("Player").transform.position = new Vector3(-17f, 1.01f, 5);
                
                GameManager.setPortalState(false);

            }/*else if (SceneManager.GetActiveScene().name == "Extralvl_1")
            {
                GameObject.Find("Player").transform.position = new Vector3(-40f, 1f, 18);
            }*/
            //
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(other.tag);
        
        /*if (other.tag=="PlayerL1")
        {
            SceneManager.LoadScene("Extralvl_1");
        }
        else if (other.tag=="PlayerL1a")
        {
            SceneManager.LoadScene("Nivel_1");
        }*/

        if (SceneManager.GetActiveScene().name == "Nivel_1")
        {
            SceneManager.LoadScene("Extralvl_1");

        }else if (SceneManager.GetActiveScene().name == "Extralvl_1")
        {
            SceneManager.LoadScene("Nivel_1");
        }
        
    }
}
