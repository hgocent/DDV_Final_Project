using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform target;
    //[SerializeField] private GameObject viewPlayerRC;
    //[SerializeField] Animator walkEnemy;
    //Vector3 currentPosition;


    RaycastHit hit;

    private void Start() {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        //walkEnemy.SetBool("isAim", false);
    }

    private void Update() {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        //Patrolling();
        
         

    }

    /*void Patrolling()
    {  
        

        if (Physics.Raycast(viewPlayerRC.transform.position, viewPlayerRC.transform.TransformDirection(Vector3.forward), out hit, 10f))  //&& (hit.collider.tag != "PlayerL1")  )
        {
            currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            if( hit.collider.gameObject.name == "Player" )
            {
                Debug.Log("HIT");
                walkEnemy.SetBool("isAim", true);
                transform.Translate(new Vector3 (2.9f, 0, -3.49f));
                transform.position = currentPosition;
            }
            else{
                walkEnemy.SetBool("isAim", false);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                
            }}
            
        
        else // else means raycast hit is returning false (when not hitting anything)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }*/
        
    
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Waypoint"){
            target = other.gameObject.GetComponent<NextPoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }

    
}    