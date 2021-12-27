using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Xdoor;
    private bool exitDoorOpened = false;
    void Start()
    {
        Xdoor = GameObject.Find("/Environment/DoorToKeyPadRoom");
        
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
            Debug.Log("2d panel for entering pin");
        }

        OpenDoors();
        
    }

    //move towards a target at a set speed.
    private void OpenDoors() 
    {
        float speed = 1f;
        
        if (exitDoorOpened == false)
        { 
            Vector3 directionOfTravel01 = new Vector3(260f, 0, 0); //amount of space to move relatively to speed of 1f
            Vector3 directionOfTravel02 = new Vector3(-260f, 0, 0);
            
            GameObject.Find("Door_Left_01").transform.Translate
            ((directionOfTravel01.x * speed * Time.deltaTime),
            (directionOfTravel01.y * speed * Time.deltaTime),
            (directionOfTravel01.z * speed * Time.deltaTime),
            Space.World);

            GameObject.Find("Door_Left_02").transform.Translate
            ((directionOfTravel02.x * speed * Time.deltaTime),
            (directionOfTravel02.y * speed * Time.deltaTime),
            (directionOfTravel02.z * speed * Time.deltaTime),
            Space.World);    
               
            
            exitDoorOpened = true;
        }
        
        
    }


}
