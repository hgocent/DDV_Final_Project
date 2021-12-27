using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private GameObject textWin;// Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            textWin.SetActive(true);
        }
    }
}
