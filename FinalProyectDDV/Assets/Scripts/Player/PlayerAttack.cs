using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserOrigin;
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float laserCooldown = 0.5f;
    [SerializeField] private float laserShoot = 1f;
    [SerializeField] private float distanceLaser = 20f;
    [SerializeField] private EnergyBarController energyBar;
    
    private float maxEnergy = 1f;
    private float currentEnergy;
    private float energyShoot = 0.15f;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    private void LaserShoot()
    {
        if(Input.GetKey("mouse 0"))
        {
            canShoot = false;
            laserShoot = 0;
            GameObject a = Instantiate(laserBullet, laserOrigin.transform.position, laserBullet.transform.rotation);
            a.GetComponent<Rigidbody>().AddForce(laserOrigin.transform.TransformDirection(Vector3.forward) * distanceLaser, ForceMode.Impulse);
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
}
