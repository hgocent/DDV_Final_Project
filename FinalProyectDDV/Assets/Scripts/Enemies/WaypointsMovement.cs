using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform target;


    private void Start() {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }
    private void Update() {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Waypoint"){
            target = other.gameObject.GetComponent<NextPoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }


    }
}    