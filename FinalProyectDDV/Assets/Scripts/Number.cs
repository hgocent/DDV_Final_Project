
using UnityEngine;

public class Number : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
       if (other.gameObject.name == "Player")
       {
           Destroy(gameObject);
           
       }
   }
}
