using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShotgun : Soldiers
{
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
        else{
            myData.IncreaseTimeShoot(Time.deltaTime);
                        
        }
        if (myData.TimeShoot > myData.ShootCoolDown )
        {
            canShoot = true;    
        }
    }
}
