using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarController : MonoBehaviour
{
    private Image sBar; //ex[SerializeField] 

    private void Start() 
    {
        sBar = GameObject.Find("/HUD/Canvas/Panel/ShieldBar").GetComponent<Image>(); //New
        //sBar.SetActive(false);
    }
    public void SetShield(float shield)
    {
        sBar.fillAmount = shield;
    }
    public void SetMaxShield(float shield)
    {
        sBar.fillAmount = shield;
    }


}
