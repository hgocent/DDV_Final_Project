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
