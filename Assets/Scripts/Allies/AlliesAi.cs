using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlliesAi : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer, enemies;
    public Vector3 walkpoint;
    public bool walkPointSet;
    public float walkPointRange;
    private bool alreadyAttacked = false;
    public float timeBetweenAttacks;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInRange;
    private EnemyWeapon enemyWeapon;
    private GameObject enemy;
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        agent = GetComponent<NavMeshAgent>();
        enemyWeapon = GetComponent<EnemyWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, enemies);
        playerInRange = Physics.CheckSphere(transform.position, attackRange, enemies);
        if (!playerInSightRange && !playerInRange)
        {
            Patrolling();
        }
        if (playerInSightRange && !playerInRange)
        {
            Chasing();
        }
        if (playerInRange && playerInSightRange)
        {
            Attack();
        }
    }
    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkpoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkpoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkpoint = new Vector3(randomX + transform.position.x, transform.position.y, randomZ = transform.position.z);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
            Patrolling();
        }
        else
        {
            SearchWalkPoint();
        }

    }
    private void Chasing()
    {
        agent.SetDestination(enemy.transform.position);
    }
    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(enemy.transform);
        enemyWeapon.Shoot();
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttck), timeBetweenAttacks);
        }
    }
    private void ResetAttck()
    {
        alreadyAttacked = false;
    }


}
