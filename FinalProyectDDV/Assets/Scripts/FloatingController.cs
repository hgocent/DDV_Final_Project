using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingController : MonoBehaviour
{
    //adjust this to change speed
    //float speed = 5f;

    //adjust this to change how high it goes
    float CylinderHeight = 0.3f;
    float FloorHeight = 3f;

    bool CanHover = true;
    Vector3 pos;
    float newY;
    // Start is called before the first frame update
    void Start()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        pos = transform.position;
        //Debug.Log(transform.position);

        //calculate what the new Y position will be
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CanHover);
        if (CanHover == true)
        {
            switch (gameObject.name)
            {
                case "Cylinder (1)":
                    newY = Mathf.Sin(Time.time * 5f);
                break;
                case "Cylinder (2)":
                    newY = Mathf.Sin(Time.time * 4f);
                break;
                case "Cylinder (3)":
                    newY = Mathf.Sin(Time.time * 3f);
                break;
                case "floor_hover1":
                    newY = Mathf.Sin(Time.time * 2f);
                break;
                case "floor_hover2":
                    newY = Mathf.Sin(Time.time * 3f);
                    FloorHeight = 4f;
                break;
                case "floor_hover3":
                    newY = Mathf.Sin(Time.time * 2.7f);
                    FloorHeight = 8f;
                break;
                case "floor_hover4":
                    newY = Mathf.Sin(Time.time * 3.1f);
                    FloorHeight = 9f;
                break;
                default:
                    //print ("Incorrect");
                break;
            }
            if(gameObject.name.Substring(0, 8) == "Cylinder")
            { 
                transform.position = new Vector3(pos.x, pos.y + (newY * CylinderHeight), pos.z);
            }
            else if (gameObject.name.Substring(0, 11) == "floor_hover")
            {
                transform.position = new Vector3(pos.x, pos.y + (newY * FloorHeight), pos.z);
            }

        }
    }
        /*void OnTriggerEnter(Collider other) 
        {
            Debug.Log(other.gameObject.name);
        }*/

        void OnCollisionEnter(Collision collider)
        {   
            //Debug.Log(collider.gameObject.name);
            if (collider.gameObject.name == "Player" && gameObject.name.Substring(0, 11) == "floor_hover")
            {
                CanHover = false;
                //Debug.Log(CanHover);
            }
        
        }
        
        /*void OnCollisionExit(Collision collider)
        {   
            
            CanHover = true;
        
        }*/
        

    
}
