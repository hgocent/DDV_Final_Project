using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    [SerializeField] private Image eBar;
    
    
    // Start is called before the first frame update
    
    
    public void SetEnergy(float energy)
    {
        eBar.fillAmount = energy;
        
    }

    public void SetMaxEnergy(float energy)
    {
        eBar.fillAmount = energy;

    }
}
