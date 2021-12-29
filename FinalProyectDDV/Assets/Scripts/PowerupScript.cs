using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    private List<GameObject> hovers = new List<GameObject>();
    private GameObject obj1;


    // Start is called before the first frame update
    void Start()
    {   
        for (int i=3; i<9; i++)
        {

            hovers.Add(GameObject.Find("/Environment/floor_hover" + i.ToString()) );
            

        }
        

        hovers[2].SetActive(false);
        hovers[3].SetActive(false);
        hovers[4].SetActive(false);
        hovers[5].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "Player")
        {
            foreach(GameObject obj in hovers)
            {
                 
                if(obj.name == "floor_hover3" || obj.name == "floor_hover4")
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
            }

        }
    }


}
