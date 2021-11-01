using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjects : MonoBehaviour
{   
    public bool isPickable = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickupObject>().ObjectToPickup = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "PlayerInteractionZone"){
            other.GetComponentInParent<PickupObject>().ObjectToPickup = null;
        }
        
    }
}
