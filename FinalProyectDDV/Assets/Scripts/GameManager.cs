using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int playerLives;
    public static int playerBar;
    public static int playerScore;
    
    public static bool isPortalOpen;
    public static int EnemyDeathCount = 0;
    
    //public HealthbarController healthbar;

    //[SerializeField] private int playerLives;
    [SerializeField] private GameObject gameoverPanel;
    //[SerializeField] private TakeDamage playerScript;

    //Make singleton
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            playerLives = 3;
            playerBar = 100;
            playerScore = 0;
            isPortalOpen = false;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerLives);

        soldier_events.OnEnemyDeath += CountEnemyDeath;
        player_events.OnPlayerDeath += ManageLives;
    }

    private void CountEnemyDeath()
    {
        EnemyDeathCount++;
        Debug.Log("Enemigos muertos: " + EnemyDeathCount); // Luego mostaremos la cantidad de enemigos eliminados en HUD;
    }

    private void ManageLives()
    {   
        
        playerLives --;
        Debug.Log("You lost 1 life");
        Debug.Log(playerLives);
        
        if (playerLives == 0)
        {
            gameoverPanel.SetActive(true);
            
            //QUE SE DETENGA EL JUEGO
            Time.timeScale = 0;
        }
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getLife()
    {
        return playerBar;
    }

    public static int getScore()
    {
        return playerScore;
    }

    public static int getLives()
    {
        return playerLives;
    }

    public static bool getPortalState()
    {
        return isPortalOpen;
    }

    public static void decreaseLife(int damage)
    {
        playerBar -= damage;
    }

    public static void increaseScore(int score)
    {
        playerScore += score;
    }

    public static void setPortalState(bool state)
    {
        isPortalOpen = state;
    }

}
