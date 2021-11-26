using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickStart()
    {
        Debug.Log("Otra escena");
        SceneManager.LoadScene("Intro");
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Nivel_1");
    }
}
