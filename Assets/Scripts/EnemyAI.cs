using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBtwnAttack;
    bool alreadyAttk;

    public float sightRange, AttackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject projectile;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) Chase();
        if (playerInSightRange && playerInAttackRange) Attack();
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
        {
            walkPointSet = true;
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalk = transform.position - walkPoint;
        if (distanceToWalk.magnitude < 1f)
        {
            walkPointSet= false;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttk)
        {
            Rigidbody enemyProjectile = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            enemyProjectile.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //enemyProjectile.AddForce(transform.up * 8f, ForceMode.Impulse);
            alreadyAttk = true;
            Invoke(nameof(ResetAttack), timeBtwnAttack);
        }
    }

    private void ResetAttack()
    {
        alreadyAttk = false;
    }
}
