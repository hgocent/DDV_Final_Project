using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private GameObject shootOrigin;
    [SerializeField] private float shootCooldown = 0.5f;
    [SerializeField] private float timeShoot = 1f;
    [SerializeField] private GameObject bulletPrefab;
    private bool canShoot = true;
    //private float timeBullet = 0f;
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

    private void RaycastWeapon()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward), out hit, distanceRay) && hit.collider.tag.Equals("PlayerL1"))
        {
            canShoot = false;
            timeShoot = 0;
            GameObject b = Instantiate(bulletPrefab, shootOrigin.transform.position, bulletPrefab.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(shootOrigin.transform.TransformDirection(Vector3.forward) * distanceRay, ForceMode.Impulse);
            
            
         }
    }

    /*private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootOrigin.transform.position, shootOrigin.transform.TransformDirection(Vector3.forward) * distanceRay);
    }*/
}
