using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private float maxHealth = 1f;
    private float currentHealth;
    private float maxShield = 1f;
    private float currentShield;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject gameoverPanel;
    

    public HealthbarController healthbar;
    public ShieldBarController shieldbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        currentShield = maxShield;
        shieldbar.SetMaxShield(maxShield);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    

    void Damage(float damage)
    {
        if ( shield.activeSelf == true)
        {
            currentHealth -= damage/4;
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


        if (shield.activeSelf == true)
        {   if (currentHealth < 0 && currentShield < 0 )
            {
                gameoverPanel.SetActive(true);
                //QUE SE DETENGA EL JUEGO
                Time.timeScale = 0;
            }
        }
        else
        {
            if(currentHealth < 0 )
            {
                gameoverPanel.SetActive(true);
                // QUE SE DETENGA EL JUEGO
                Time.timeScale = 0;             
            }
        }
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            Damage(0.05f);
        }
        
    }
}
