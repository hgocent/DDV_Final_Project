using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private List<GameObject> luces;
    // Start is called before the first frame update
    public void OnLights()
    {
        luces[0].SetActive(true);
        luces[1].SetActive(true);
        luces[2].SetActive(true);
    }
    // Update is called once per frame
}