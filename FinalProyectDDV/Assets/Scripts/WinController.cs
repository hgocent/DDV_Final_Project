using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Xdoor;
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
            Debug.Log("Entering 2d panel for entering pin");
        }
    }
}
