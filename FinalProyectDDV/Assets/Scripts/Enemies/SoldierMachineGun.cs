using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMachineGun : Soldiers
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
            timeShoot += Time.deltaTime;
                        
        }
        if (timeShoot > shootCooldown )
        {
            canShoot = true;    
        }
    }
}
