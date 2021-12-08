
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{   
    [SerializeField] private PostProcessingController postPContScr;

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

    public void OnClickSettings()
    {
        //postPContScr._bloomOnOff(true);
        //Debug.Log(GameManager.setPprocessingCheckmark());
        SceneManager.LoadScene("Settings");
    }

    public void OnClickBack()
    {
        //Debug.Log("CARGAR");
        SceneManager.LoadScene("MainMenu");
    }
}
