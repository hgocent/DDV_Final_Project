using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarController : MonoBehaviour
{
    [SerializeField] private Image sBar;

    public void SetShield(float shield)
    {
        sBar.fillAmount = shield;
    }
    public void SetMaxShield(float shield)
    {
        sBar.fillAmount = shield;
    }
    




}
