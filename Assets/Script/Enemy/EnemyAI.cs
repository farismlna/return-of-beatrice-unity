using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    float speedRun = 3f;
    public float damage = 1;

    private Animator anim;
    bool isWalking;

    //Another Script
    FieldOfView fieldOfView;
    public bool inRadiusView;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //fieldOfView = GetComponent<FieldOfView>().canSeePlayer;
    }

    // Update is called once per frame
    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange && !gameObject.GetComponent<FieldOfView>().canSeePlayer) Patroling();
        if (playerInSightRange && !playerInAttackRange && gameObject.GetComponent<FieldOfView>().canSeePlayer) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        StartCoroutine(DelayWalkPoint());

        if (walkPointSet)
        {
            StopAllCoroutines();
            agent.SetDestination(walkPoint);
            anim.SetBool("IsWalking", true);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            anim.SetBool("IsWalking", false);
            new WaitForSeconds(4f);
        }
    }

    IEnumerator DelayWalkPoint()
    {
        //delay setelah walk point di set
        if (!walkPointSet)
        {
            yield return new WaitForSeconds(5f);
            SearchWalkPoint();
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        //naikin speed saat mengejar player
        while (agent.speed < speedRun)
        {
            agent.speed = agent.speed + 0.5f;
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsWalking", false);
        }
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsRunning", false);
        walkPointSet = false;

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            StartCoroutine(AttackAnimation());
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(1);
            // ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
    }

    IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);

        anim.SetInteger("AttackIndex", Random.Range(0, 2));
        anim.SetTrigger("Attack");
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsWalking", false);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetTrigger("damage");

        if (health <= 0)
            DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
        StopCoroutine(AttackAnimation());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
