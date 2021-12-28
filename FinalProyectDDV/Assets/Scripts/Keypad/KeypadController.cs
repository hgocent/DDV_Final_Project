using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    [SerializeField] private InputField code;
    [SerializeField] private GameObject keyPadpanel;
    private WinController wController;

    private Text kPadText;
    private string correctPass = "8925";
    
        
    private string addNumber0 = "0";
    private string addNumber1 = "1";
    private string addNumber2 = "2";
    private string addNumber3 = "3";
    private string addNumber4 = "4";
    private string addNumber5 = "5";
    private string addNumber6 = "6";
    private string addNumber7 = "7";
    private string addNumber8 = "8";
    private string addNumber9 = "9";
    private string delete = "";
    

    void Start()
    {
        kPadText = GameObject.Find("/HUD/KeypadCanvas/Panel/InputField/Placeholder").GetComponent<Text>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Nivel_2")
        {
            wController = GameObject.Find("/Environment/ATM_Cyan/PanelTrigger").GetComponent<WinController>();
        }
    }
    public void OnClickEnter0()
    {
        
        code.text += addNumber0;
    }
    public void OnClickEnter1()
    {
        
        code.text += addNumber1;
    }
    public void OnClickEnter2()
    {
        
        code.text += addNumber2;
    }
    public void OnClickEnter3()
    {
        
        code.text += addNumber3;
    }
    public void OnClickEnter4()
    {
        
        code.text += addNumber4;
    }
    public void OnClickEnter5()
    {
        
        code.text += addNumber5;
    }
    public void OnClickEnter6()
    {
        
        code.text += addNumber6;
    }
    public void OnClickEnter7()
    {
        
        code.text += addNumber7;
    }
    public void OnClickEnter8()
    {
        
        code.text += addNumber8;
    }
    public void OnClickEnter9()
    {
        
        code.text += addNumber9;
    }
    
    public void OnClickDelete()
    {
        kPadText.text = "INSERT CODE";
        code.text = delete;
    }

    public void OnClickOK()
    {
        int txtlives = GameManager.getLives() -1;

        if (code.text != correctPass)
        {

            code.text = delete;
            kPadText.text = "WRONG! - " + txtlives.ToString() + " Attempt(s) Left";
            //restar vida
            
            player_events.OnPlayerDeath();
        }
        else 
        {
            //keyPadpanel.SetActive(false);
            Time.timeScale = 1f;
            wController.OpenDoors();
            Destroy(keyPadpanel);
            
        }

    }

    


}
