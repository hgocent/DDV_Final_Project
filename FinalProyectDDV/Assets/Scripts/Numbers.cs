using UnityEngine;
using TMPro;

public class Numbers : MonoBehaviour
{
    [SerializeField] private GameObject textR;
   private void OnCollisionEnter(Collision other) {
       if (other.gameObject.name == "Player")
       {
           Debug.Log("Remember the number");
           textR.SetActive(true);
           Destroy(gameObject);
           Destroy(textR, 2f);
       }
   }
}
