using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int playerLives;
    public static float playerLifeBar; 
    public static float PlayerShieldBar;
    public static float PlayerEnergyBar;
    public static int playerScore;
    
    public static bool isExtraLevelGreenPortalOpen;
    public static bool isMiniGameWon;
    public static int EnemyDeathCount = 0;
    
    public static bool pProcessingCheckmark;

    public static String thisLevel;
    //public HealthbarController healthbar;

    //[SerializeField] private int playerLives;
    [SerializeField] private GameObject gameoverPanel;
    
    //private GameObject livesText;
    //private GameObject deathsText;

    //Image gameoverImg;
    //Text gameoverTxt;
    //[SerializeField] private TakeDamage playerScript;

    //Make singleton
    private void Awake()
    {   
        if(instance == null)
        {
            instance = this;
            playerLives = 3;
            playerLifeBar = 1f;
            PlayerShieldBar = 1f;
            PlayerEnergyBar = 1f;
            playerScore = 0;
            isExtraLevelGreenPortalOpen = false;
            DontDestroyOnLoad(gameObject);
            

        }/*else if (instance != this) //Instance is not the same as the one we have, destroy old one, and reset to newest one
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }*/
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*gameoverImg = gameoverPanel.GetComponent<Image>(); //New
        gameoverImg.enabled = false; //New

        gameoverTxt = gameoverPanel.transform.GetChild(0).GetComponent<Text>(); //New
        gameoverTxt.enabled = false; //New
        */

        //livesText = GameObject.Find("/HUD/Canvas/Panel/LivesText");
        //livesText.GetComponent<Text>().text = playerLives.ToString(); //set value on HUD

        //deathsText = GameObject.Find("/HUD/Canvas/Panel/DeathText");
    
        Debug.Log("Lives: " + playerLives);

        soldier_events.OnEnemyDeath += CountEnemyDeath;
        player_events.OnPlayerDeath += ManageLives;
        player_events.OnPlayerCliff += OnCliff;
        
    }

    void Update()
    {
        
    }
    private void CountEnemyDeath()
    {
        EnemyDeathCount++;

        if(getEnemyDeathCount() > 0)
        {
            Debug.Log("Maté un enemigo, debo mover el portal. " + GameObject.Find("/ENVIROMENT--/ExtraLvl").transform.position);
            GameObject.Find("/ENVIROMENT--/ExtraLvl").transform.position = new Vector3(-11f,8f,-80f);
        }

        //Debug.Log("Enemigos muertos: " + EnemyDeathCount);
        //deathsText.GetComponent<Text>().text = EnemyDeathCount.ToString(); //set value on HUD
    }

    private void ManageLives()
    {   
        
        playerLives --;
        Debug.Log("You lost 1 life");
        //Debug.Log("Lives left: " + playerLives);
        
        if (playerLives <= 0)
        {
            player_events.OnPlayerDeath -= ManageLives;

            gameoverPanel.SetActive(true);  //Old
            //gameoverImg.enabled = true; //New
            //gameoverTxt.enabled = true; //New

            //QUE SE DETENGA EL JUEGO
            Time.timeScale = 0;
        }
        //livesText.GetComponent<Text>().text = playerLives.ToString(); //set value on HUD

    }

    private void OnCliff()
    {
        playerLives = 1;
        ManageLives();
        
        
    }

    public static bool getPprocessingCheckmark()
    {
        return pProcessingCheckmark;
    }

    public static int getEnemyDeathCount()
    {
        return EnemyDeathCount;
    }
    public static float getLife()
    {
        return playerLifeBar;
    }

    public static float getShieldMeter()
    {
        return PlayerShieldBar;
    }

    public static float getEnergyMeter()
    {
        return PlayerEnergyBar;
    }
    public static int getScore()
    {
        return playerScore;
    }

    public static int getLives()
    {
        return playerLives;
    }

    public static bool getExtraLevelGreenPortalState()
    {
        return isExtraLevelGreenPortalOpen;
    }

    public static bool setPprocessingCheckmark()
    {
        return (pProcessingCheckmark = !pProcessingCheckmark);
    }
    public static void setLife(float newLife) //ex decreaseLife
    {
        playerLifeBar = newLife;
    }

    public static void setShieldMeter(float newShieldValue) //ex decreaseShield
    {
        PlayerShieldBar = newShieldValue;
    }

    public static void setPEnergyMeter(float newEnergy)
    {
        PlayerEnergyBar = newEnergy;
    }
    public static void increaseScore(int score)
    {
        playerScore += score;
    }

    public static void setExtraLevelGreenPortalState(bool state)
    {
        isExtraLevelGreenPortalOpen = state;
    }

}
