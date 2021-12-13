using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private float maxHealth = 1f;
    private float currentHealth;
    private float maxShield = 1f;
    private float currentShield;
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
        
        ResetLifeBar();
    }

    // Update is called once per frame
    void Update()
    {
        //verificar si tengo lifebar
        //poner <= en current health si queremos que la verificacion sea instantanea al momento d perder la vida sino dejar en < para que la ultima bala indique la perdida completa d vida y dispare OnPlayerDeath;

        //if (shield.activeSelf == true)
        {   if ((shield.activeSelf == true && currentHealth <= 0 && currentShield <= 0 ) || (shield.activeSelf == false && currentHealth <= 0))
            {
                //gameoverPanel.SetActive(true);
                //QUE SE DETENGA EL JUEGO
                //Time.timeScale = 0;

                player_events.OnPlayerDeath();
                
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
            currentHealth -= damage/2;
            healthbar.SetHealth(currentHealth);
            currentShield -= damage;
            shieldbar.SetShield(currentShield);
            if (currentShield < 0 )
            {
                currentHealth -= damage;
                healthbar.SetHealth(currentHealth);
            }
        }
        else
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);            
        }


        //ex verificacion de vida

        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            Damage(0.25f);
        }
        
    }

    private void ResetLifeBar()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        currentShield = maxShield;
        shieldbar.SetMaxShield(maxShield);
    }
}
