using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillValueNumber : MonoBehaviour
{
    public Image HealthImg;
    public Image EnergyImg;
    // Update is called once per frame
    void Update()
    {
        float Hamount = HealthImg.fillAmount * 100;
        gameObject.GetComponent<Text>().text = Hamount.ToString("F0");

        float Eamount = EnergyImg.fillAmount * 100;
        gameObject.GetComponent<Text>().text = Eamount.ToString("F0");
    }


    
}
