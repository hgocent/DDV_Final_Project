using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserOrigin; 
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private GameObject powerUp; 
    private GameObject powerUpLife;
    [SerializeField] private float laserCooldown = 0.5f;
    [SerializeField] private float laserShoot = 1f;
    [SerializeField] private float distanceLaser = 20f;
    private EnergyBarController energyBar; // ex [SerializeField]
    [SerializeField] private float speedBullet = 0.5f;
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private AudioSource pUpsound;
    
   //private float maxEnergy = 1f; //1f
    //private float currentEnergy;
    [SerializeField] private float energyShoot = 0.10f; //% of energy per laser shoot
    private bool canShoot = true;

    public Transform cam; //New
    //int counter=0;

    // Start is called before the first frame update
    void Start()
    {   
        if(GameObject.Find("/HUD/Canvas/Panel/Energy bar").GetComponent<EnergyBarController>() != null)
        {
            energyBar = GameObject.Find("/HUD/Canvas/Panel/Energy bar").GetComponent<EnergyBarController>(); //////////////////////
        }
              
        if (GameObject.Find("PowerUpLife")!= null)
        {
            powerUpLife = GameObject.Find("PowerUpLife");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (canShoot)
        {
            LaserShoot();
        }
        else
        {
            laserShoot += Time.deltaTime;
        }
        if (laserShoot > laserCooldown)
        {
            
            if (GameManager.getEnergyMeter() <= 0) // old local function - if (currentEnergy < 0)
            { 
                canShoot = false;              
                //Debug.Log("Sin energia");
            }else 
            {
                canShoot = true;
            }
        }


    }


    

    private void LaserShoot()
    {   
        Vector3 hitPosition; 
        Vector3 direction; 

        if(Input.GetKey("mouse 0") && Input.GetKey("mouse 1"))
        {   
            //Debug.Log("mouse click");

            hitPosition = cam.transform.position + cam.forward * 10; //
            direction = hitPosition - laserOrigin.transform.position; //

            canShoot = false;
            laserShoot = 0;
            fireSound.Play();
            
            GameObject a = Instantiate(laserBullet, laserOrigin.transform.position, laserBullet.transform.rotation);
            a.transform.forward = direction; //New

           //a.GetComponent<Rigidbody>().AddForce(laserOrigin.transform.TransformDirection(Vector3.forward) * distanceLaser, ForceMode.Impulse);

            a.GetComponent<Rigidbody>().AddForce((direction.normalized * distanceLaser)*speedBullet, ForceMode.Impulse); //
            
            
            GameManager.setPEnergyMeter(GameManager.getEnergyMeter()-energyShoot);
            energyBar.SetEnergy(GameManager.getEnergyMeter());
            
            if (GameManager.getEnergyMeter() <= 0)
            {
                canShoot = false;
                laserShoot = 0;
                laserCooldown = 0;
                //Debug.Log("Sin energia");
            }



        }
        
    }
    
    //old local function
    /*private void DecreaseEnergy(float energy)
    {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);

    }*/

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PowerUp")
        {
            pUpsound.Play();
            Destroy(powerUp);

            GameManager.setPEnergyMeter(1f);
            energyBar.SetEnergy(1f);           
            //old local functions - currentEnergy = maxEnergy;            
            //old local functions - energyBar.SetEnergy(currentEnergy);
            
        }
        else if (other.tag == "PowerUpLife")
        {
            GameManager.addLivesToPlayer(1);
            powerUpLife.SetActive(false);
        }

    }
}
