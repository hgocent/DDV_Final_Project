using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    //private float maxHealth = 1f;
    //; // is equal to GameManager.PlayerLifeBar
    //private float maxShield = 1f;
    //private float currentShield; //is equal to GameManager.PlayerShieldBar
    private GameObject shield; //  [SerializeField] 
    //[SerializeField] private GameObject gameoverPanel;
    

    private HealthbarController healthbar; //ex public
    private ShieldBarController shieldbar; //ex public
    // Start is called before the first frame update
    void Start()
    {   
        shield = GameObject.Find("/HUD/Canvas/Panel/ShieldBar");

        healthbar = GameObject.Find("/HUD/Canvas/Panel/HealthBar/HealthBar").GetComponent<HealthbarController>();
        shieldbar = GameObject.Find("/HUD/Canvas/Panel/ShieldBar/ShieldBar").GetComponent<ShieldBarController>();

        if (GameManager.isMiniGameWon == false)
        {
            shield.SetActive(false);
        }
        
        //currentHealth = GameManager.getLife(); //
        //currentShield = GameManager.getShieldMeter(); //

        //ResetLifeBar(); //get healthbar & shieldbar from game manager on start and if its starts from begining it should be full
    }

    // Update is called once per frame
    void Update()
    {
        //verificar si tengo lifebar
        //poner <= en current health si queremos que la verificacion sea instantanea al momento d perder la vida sino dejar en < para que la ultima bala indique la perdida completa d vida y dispare OnPlayerDeath;

        //if (shield.activeSelf == true)
        {   if ((shield.activeSelf == true && GameManager.getLife() <= 0 && GameManager.getShieldMeter() <= 0 ) || (shield.activeSelf == false && GameManager.getLife() <= 0))
            {
                //gameoverPanel.SetActive(true);
                //QUE SE DETENGA EL JUEGO
                //Time.timeScale = 0;

                if (player_events.OnPlayerDeath != null) //if none is suscribed I do not call it
                {
                    player_events.OnPlayerDeath();
                }

                if (GameManager.playerLives > 0)
                {
                    ResetLifeBar();
                }
                
                
                
            }
        }
        /*else
        {
            if(currentHealth < 0 )
            {
                //gameoverPanel.SetActive(true);
                // QUE SE DETENGA EL JUEGO
                //Time.timeScale = 0;
                player_events.OnPlayerDeath();             
            }
        }*/
        
        
        
    }
    

    void Damage(float damage)
    {
        if ( shield.activeSelf == true)
        {
            GameManager.setLife( GameManager.getLife() - (damage/2) );  //ex currentHealth -= damage/2;
            healthbar.setHealth( GameManager.getLife() ); //ex healthbar.setHealth(currentHealth);

            GameManager.setShieldMeter( GameManager.getShieldMeter() - damage );//ex currentShield -= damage;
            shieldbar.setShield( GameManager.getShieldMeter() );//ex shieldbar.SetShield(currentShield);
            
            if ( GameManager.getShieldMeter() < 0 )
            {
                GameManager.setLife( GameManager.getLife() - (damage/2) ); //ex currentHealth -= damage;
                healthbar.setHealth( GameManager.getLife() ); //ex healthbar.setHealth(currentHealth);
            }
        }
        else
        {
            GameManager.setLife( GameManager.getLife() - (damage/2) ); //ex currentHealth -= damage;
            healthbar.setHealth( GameManager.getLife() ); //ex healthbar.setHealth(currentHealth);           
        }


        //ex verificacion de vida

        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            Damage(0.2f);
        }
        
    }

    private void ResetLifeBar()
    {
        GameManager.setLife(1f); //ex currentHealth = maxHealth;
        healthbar.setHealth(1f); //ex healthbar.SetMaxHealth(maxHealth);

        //GameManager.setShieldMeter(1f); //ex currentShield = maxShield; //no resetear el shield, solo vale por 1 cada vez que lo obtiene
        //shieldbar.setShield(1f); //ex shieldbar.SetMaxShield(maxShield);
    }
}
