using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    private Image eBar; // ex [SerializeField] 
    
    
    // Start is called before the first frame update
    private void Start() 
    {
        eBar = GameObject.Find("/HUD/Canvas/Panel/Energy bar").GetComponent<Image>(); //New
    }
    
    public void SetEnergy(float energy)
    {
        eBar.fillAmount = energy;
        
    }

    /*public void SetMaxEnergy(float energy)
    {
        eBar.fillAmount = energy;

    }*/
}
