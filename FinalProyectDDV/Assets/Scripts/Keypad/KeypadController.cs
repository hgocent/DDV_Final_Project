using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    [SerializeField] private InputField code;
    [SerializeField] private GameObject keyPadpanel;
    [SerializeField] private WinController wController;

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
    

    
    
    public void OnClickEnter0()
    {
        Debug.Log("0");
        code.text += addNumber0;
    }
    public void OnClickEnter1()
    {
        Debug.Log("1");
        code.text += addNumber1;
    }
    public void OnClickEnter2()
    {
        Debug.Log("2");
        code.text += addNumber2;
    }
    public void OnClickEnter3()
    {
        Debug.Log("3");
        code.text += addNumber3;
    }
    public void OnClickEnter4()
    {
        Debug.Log("4");
        code.text += addNumber4;
    }
    public void OnClickEnter5()
    {
        Debug.Log("5");
        code.text += addNumber5;
    }
    public void OnClickEnter6()
    {
        Debug.Log("6");
        code.text += addNumber6;
    }
    public void OnClickEnter7()
    {
        Debug.Log("7");
        code.text += addNumber7;
    }
    public void OnClickEnter8()
    {
        Debug.Log("8");
        code.text += addNumber8;
    }
    public void OnClickEnter9()
    {
        Debug.Log("9");
        code.text += addNumber9;
    }
    
    public void OnClickDelete()
    {
        Debug.Log("Delete");
        code.text = delete;
    }

    public void OnClickOK()
    {
        if (code.text != correctPass)
        {
            code.text = delete;
        }
        else 
        {
            keyPadpanel.SetActive(false);
            wController.OpenDoors();
        }

    }

    


}
