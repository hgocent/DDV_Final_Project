using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int playerLife;
    public static int playerScore;

    public static bool isPortalOpen;
    public static int EnemyDeathCount = 0;
    private Soldiers soldierScript;
    
    [SerializeField] private TakeDamage playerScript;

    //Make singleton
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            playerLife = 100;
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
        //soldierScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Soldiers>();
        soldierScript = FindObjectOfType<Soldiers>();
        soldierScript.OnEnemyDeath += CountEnemyDeath;
    }

    private void CountEnemyDeath()
    {
        EnemyDeathCount++;
        Debug.Log("Enemigos muertos: " + EnemyDeathCount); // Luego mostaremos la cantidad de enemigos eliminados en HUD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getLife()
    {
        return playerLife;
    }

    public static int getScore()
    {
        return playerScore;
    }

    public static bool getPortalState()
    {
        return isPortalOpen;
    }

    public static void decreaseLife(int damage)
    {
        playerLife -= damage;
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
