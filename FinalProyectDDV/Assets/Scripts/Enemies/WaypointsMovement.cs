using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject viewPlayerRC;

    RaycastHit hit;

    private void Start() {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    private void Update() {

        Patrolling();

    }

    void Patrolling()
    {   
    
        if (Physics.Raycast(viewPlayerRC.transform.position, viewPlayerRC.transform.TransformDirection(Vector3.forward), out hit, 10f))  //&& (hit.collider.tag != "PlayerL1")  )
        {
            if( hit.collider.gameObject.name != "Player" )
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
        }
        else // else means raycast hit is returning false (when not hitting anything)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
       

    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Waypoint"){
            target = other.gameObject.GetComponent<NextPoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }


    }
}    