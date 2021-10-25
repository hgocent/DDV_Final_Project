using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{   
    public GameObject ObjectToPickup;
    public GameObject PickedObject;
    public Transform LHand;
    
       
    void Update()
    {
        if (ObjectToPickup != null && ObjectToPickup.GetComponent<PickableObjects>().isPickable == true && PickedObject == null){
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickup;
                PickedObject.GetComponent<PickableObjects>().isPickable = false;
                PickedObject.transform.SetParent(LHand);
                PickedObject.transform.position = LHand.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (PickedObject != null)
        {
            if(Input.GetKeyDown(KeyCode.F)){
                
                PickedObject.GetComponent<PickableObjects>().isPickable = true;
                PickedObject.transform.SetParent(null);                
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;  
            }
        }

    }
}
