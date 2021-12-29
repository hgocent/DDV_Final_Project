using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelZeroPortal : MonoBehaviour
{
    private int rndSwitch;
    private float time;
    private float timeStore = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Invoke("TransportPortal", 3f);
        
        if (time > 0) 
        {
         time -= Time.deltaTime;
        } 
        else 
        {
            //Do Stuff
            StartCoroutine(TransportPortal());    
            time = timeStore;        
        }

        
    }

    IEnumerator TransportPortal()
    {   
        yield return new WaitForSeconds(3f);
        
        rndSwitch = UnityEngine.Random.Range(1, 8);
        //Debug.Log(rndSwitch);

        switch (rndSwitch)
        {
            case 1:
                transform.position = new Vector3(7f,1.5f,12f);
            break;

            case 2:
                transform.position = new Vector3(30f,1.5f,18f);
            break;

            case 3:
                transform.position = new Vector3(40f,1.5f,5f);
            break;

            case 4:
                transform.position = new Vector3(62f,1.5f,12f);
            break;

            case 5:
               transform.position = new Vector3(86f,1.5f,20f);
            break;

            case 6:
               transform.position = new Vector3(116f,1.5f,8f);
            break;

            case 7:
               transform.position = new Vector3(109f,1.5f,-10f);
            break;

            default:
                //print ("Incorrect");
            break;
        }

    }

     public void OnTriggerEnter(Collider other) 
    {
        SceneManager.LoadScene("Nivel_1");
    }
}
