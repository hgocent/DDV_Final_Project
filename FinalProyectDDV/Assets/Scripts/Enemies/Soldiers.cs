using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{  
    [SerializeField] private GameObject shootOrigin;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] protected SoldierData myData;
    
    protected bool canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            RaycastWeapon();
            
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
            myData.NullTimeShoot();           
            GameObject b = Instantiate(bulletPrefab, shootOrigin.transform.position, bulletPrefab.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(shootOrigin.transform.TransformDirection(Vector3.forward) * myData.DistanceRay, ForceMode.Impulse);
                      
         }
    }

   public void OnTriggerEnter(Collider other) {
       if (other.tag == "Laser")
       {
           Destroy(gameObject);
       }
   }

    public void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward) * myData.DistanceRay);
    }
}
