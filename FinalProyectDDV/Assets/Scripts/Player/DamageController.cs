using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public GameObject casa;
    // Start is called before the first frame update
    void Start()
    {
        casa = GameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.GetComponent<Healthbar>().FillAmount = ((GameManager.playerLife - 5)/100f);
        }
    }
}
