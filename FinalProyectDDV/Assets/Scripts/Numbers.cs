using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) {
       if (other.gameObject.name == "Player")
       {
           Debug.Log("Remember the number");
           Destroy(gameObject);
       }
   }
}
