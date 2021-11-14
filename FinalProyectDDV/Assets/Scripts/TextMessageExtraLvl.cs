using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //Debug.Log("I'M IN");
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("Get the same color in all circles");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("MiniGameMsg").GetComponent<TextMesh>().text = ("");

        }
    }

}
