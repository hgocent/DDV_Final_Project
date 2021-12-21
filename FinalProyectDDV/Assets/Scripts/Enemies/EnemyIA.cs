using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;
    [SerializeField] GameObject shootOrigin;
    [SerializeField] GameObject bulletPrefab;

    //Patroling
    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float wailkPointRange;

    //Attacking
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    [SerializeField] float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() 
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Wallpoint reached
        if (distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-wailkPointRange, wailkPointRange);
        float randomX = Random.Range(-wailkPointRange, wailkPointRange);

        walkPoint = new Vector3 (transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn´t move
        agent.SetDestination(transform.position);
        
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here
            GameObject b = Instantiate(bulletPrefab, shootOrigin.transform.position, bulletPrefab.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(shootOrigin.transform.TransformDirection(Vector3.forward) * 32f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }




}
