using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSingleton : MonoBehaviour
{
    public static HUDSingleton instance;
    private void Awake()
    {   
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
