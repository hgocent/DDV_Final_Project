using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    private Image  hBar; //[SerializeField] 
    
    
    // Start is called before the first frame update
    
    private void Start() 
    {
       hBar = GameObject.Find("/HUD/Canvas/Panel/HealthBar").GetComponent<Image>(); //New

    }
    public void SetHealth(float health)
    {
        hBar.fillAmount = health;
        
    }

    public void SetMaxHealth(float health)
    {
        hBar.fillAmount = health;

    }
}
