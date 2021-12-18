using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soldiers : MonoBehaviour
{  
    [SerializeField] private GameObject shootOrigin;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] protected SoldierData myData;
    
    //[SerializeField] private ParticleSystem muzzleShoot; //temporarily turned off
    
    
    private float enemyHp;
    
    protected bool canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = myData.Hp;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            RaycastWeapon();
            //muzzleShoot.Play(); //temp off
        }
        else
        {
            myData.IncreaseTimeShoot(Time.deltaTime);            
            
        }

        if (myData.TimeShoot > myData.ShootCoolDown )
        {
            canShoot = true;    
        }

    }

    public void RaycastWeapon()
    {   
        
        RaycastHit hit;
        
        if(Physics.Raycast(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward), out hit, myData.DistanceRay) && hit.collider.tag.Equals("PlayerL1"))
        {
            
            canShoot = false;   
            //muzzleShoot.Play();         
            myData.NullTimeShoot();           
            GameObject b = Instantiate(bulletPrefab, shootOrigin.transform.position, bulletPrefab.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(shootOrigin.transform.TransformDirection(Vector3.forward) * myData.DistanceRay, ForceMode.Impulse);
                      
        }
        
    }

   public void OnTriggerEnter(Collider other) {
       if (other.tag == "Laser")
       {
           
           enemyHp -= 1f;
           
           if (enemyHp <= 0)
           {
                //Debug.Log(enemyHp);
                soldier_events.OnEnemyDeath();
                Destroy(gameObject);
           }
           
           
       }
   }

    public void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward) * myData.DistanceRay);
    }

    
    
}

public static class soldier_events
{
    public static Action OnEnemyDeath;
}

