using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Xdoor;
    private GameObject kPad; //ex serialized
    private bool exitDoorOpened = false;
    void Start()
    {
        Xdoor = GameObject.Find("/Environment/DoorToKeyPadRoom");
        kPad = GameManager.kPad; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Xdoor.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player")
        {
            //Debug.Log("enter pin");
            if (kPad != null)
            {
               kPad.SetActive(true); 
               Time.timeScale = 0;
            }
            
        }

        //OpenDoors();
        
    }

    //move towards a target at a set speed.
    public void OpenDoors() 
    {
        //float speed = 1f;
        
        if (exitDoorOpened == false)
        { 
            Vector3 directionOfTravel01 = new Vector3(33f, 18.58f, 393.91f); //amount of space to move relatively to speed of 1f
            Vector3 directionOfTravel02 = new Vector3(-37f, 18.58f, 396.89f);
            
            /*GameObject.Find("Door_Left_01").transform.Translate
            ((directionOfTravel01.x * speed * Time.deltaTime),
            (directionOfTravel01.y * speed * Time.deltaTime),
            (directionOfTravel01.z * speed * Time.deltaTime),
            Space.World);

            GameObject.Find("Door_Left_02").transform.Translate
            ((directionOfTravel02.x * speed * Time.deltaTime),
            (directionOfTravel02.y * speed * Time.deltaTime),
            (directionOfTravel02.z * speed * Time.deltaTime),
            Space.World);*/

            GameObject.Find("Door_Left_01").transform.position = directionOfTravel01;
            GameObject.Find("Door_Left_02").transform.position = directionOfTravel02;    
               

            exitDoorOpened = true;
        }
        
        
    }


}
