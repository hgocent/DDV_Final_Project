using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private Image  hBar;
    
    
    // Start is called before the first frame update
    
    
    public void SetHealth(float health)
    {
        hBar.fillAmount = health;
        
    }

    public void SetMaxHealth(float health)
    {
        hBar.fillAmount = health;

    }
}
