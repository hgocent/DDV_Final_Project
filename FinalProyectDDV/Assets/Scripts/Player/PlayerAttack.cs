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
    [SerializeField] private float laserCooldown = 0.5f;
    [SerializeField] private float laserShoot = 1f;
    [SerializeField] private float distanceLaser = 20f;
    private EnergyBarController energyBar; // ex [SerializeField] 
    [SerializeField] private float speedBullet = 0.5f;
    [SerializeField] private AudioSource fireSound;
    
    private float maxEnergy = 1f;
    private float currentEnergy;
    private float energyShoot = 0.10f;
    private bool canShoot = true;

    public Transform cam; //New
    int counter=0;

    // Start is called before the first frame update
    void Start()
    {
        energyBar = GameObject.Find("/HUD/Canvas/Panel/Energy bar").GetComponent<EnergyBarController>(); //////////////////////
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
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
            
            if (currentEnergy < 0){
                canShoot = false;
                //laserShoot = 0;                
                //Debug.Log("Sin energia");
            }else {
                canShoot = true;
            }
        }

        //temporal
        /*if (SceneManager.GetActiveScene().name == "Extralvl_1" && counter != 1)
        {
            energyBar = GameObject.Find("/HUD/Canvas/Panel/Energy bar").GetComponent<EnergyBarController>(); //////////////////////
            counter = 1;
        }*/

    }


    

    private void LaserShoot()
    {   
        Vector3 hitPosition; //new
        Vector3 direction; //New

        if(Input.GetKey("mouse 0") && Input.GetKey("mouse 1"))
        {   
            //Debug.Log("mouse click");

            hitPosition = cam.transform.position + cam.forward * 10; //New
            direction = hitPosition - laserOrigin.transform.position; //New

            canShoot = false;
            laserShoot = 0;
            fireSound.Play();
            
            GameObject a = Instantiate(laserBullet, laserOrigin.transform.position, laserBullet.transform.rotation);
            a.transform.forward = direction; //New

           //a.GetComponent<Rigidbody>().AddForce(laserOrigin.transform.TransformDirection(Vector3.forward) * distanceLaser, ForceMode.Impulse);

            a.GetComponent<Rigidbody>().AddForce((direction.normalized * distanceLaser)*speedBullet, ForceMode.Impulse); //new
            
            DecreaseEnergy(energyShoot);
            
            if (currentEnergy < 0){
                canShoot = false;
                laserShoot = 0;
                laserCooldown = 0;
                //Debug.Log("Sin energia");
            }



        }
        
    }

    private void DecreaseEnergy(float energy)
    {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PowerUp")
        {
            currentEnergy = maxEnergy;            
            energyBar.SetEnergy(currentEnergy);
            Destroy(powerUp);
        }
    }
}
