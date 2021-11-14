using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private bool button = false;
    //private float timerCountDown = 3.0f;
    private float rndSwitch; 
    private bool c1 = false; 
    private bool c2 = false;
    private bool c3 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button == true)
        {
            button = false;
            
            //Invoke("ChangeColor(1)",0.5f);
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
            else
            {
                
                GameObject.Find("Cylinder (1)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                GameObject.Find("Cylinder (2)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                GameObject.Find("Cylinder (3)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);

                c1 = false;
                c2 = false;
                c3 = false;
            } 
            
            if (GameObject.Find("Cylinder (1)").GetComponent<Renderer>().material.GetColor("_Color") == Color.green)
            {
                Debug.Log("cylinder 1 is green");
            } 


            /*timerCountDown -= Time.deltaTime;

            //button = false;

            if (timerCountDown <= 0)
            {
                GameObject.Find("Cylinder (1)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                GameObject.Find("Cylinder (2)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                GameObject.Find("Cylinder (3)").GetComponent<Renderer>().material.SetColor("_Color", Color.white);

                c1 = false;
                c2 = false;
                c3 = false;

                timerCountDown = 3.0f;

            }
            */

            /*if (timerCountDown <= 0)
            {
                //
                //Debug.Log("Hit wall for 2 seconds");
                
                newPosition=new Vector3(Random.Range(1,6),2,Random.Range(-3,3));
                wall.position = newPosition;
                wall.Rotate(0,Random.Range(0,360),0);
                
                timerCountDown = 2.0f;
                isPlayerColliding = false;
            }*/
        }

    }

    void ChangeColor(int c)
    {  
        rndSwitch = Random.Range(1, 4); 
        //Debug.Log("RANDOM IN SWITCH: "+ rndSwitch);
        
        switch(rndSwitch)
        {
            case 1:
            //Debug.Log("HOLA");
            GameObject.Find("Cylinder ("+ c +")").GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            break;
            
            case 2:
            GameObject.Find("Cylinder ("+ c +")").GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            break;
            
            case 3:
            GameObject.Find("Cylinder ("+ c +")").GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            break;
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        button = true;

        //Debug.Log("I'M IN");
        //if (other.gameObject.tag == "Player")
        //{
        //    GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("Get the same color in all circles");
        //}
    }
    
    private void OnTriggerExit(Collider other)
    {
        button = false;
        //if (other.gameObject.tag == "Player")
        //{
        //    GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("");

        //}
    }


}
