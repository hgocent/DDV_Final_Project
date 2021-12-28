using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    //private GameObject textWin;
    
    void Start()
    {
        //textWin = GameManager.wCanv;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerL1")
        {
            GameManager.wCanv.SetActive(true);
        }
    }
}
