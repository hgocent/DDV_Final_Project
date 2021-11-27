using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboController : MonoBehaviour
{
    [SerializeField] GameObject shield;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) 
    {
      if (other.tag == "PlayerL1")
      {
          shield.SetActive(true);
                   
          Destroy(gameObject);
      }   
    }
}
