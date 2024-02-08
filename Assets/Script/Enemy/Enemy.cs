using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SG
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] float health = 3;
        [SerializeField] GameObject hitVFX;

        [Header("Combat")]
        [SerializeField] float attackCD = 3f;
        [SerializeField] float attackRange = 1.5f;
        [SerializeField] float aggroRange = 4f;

        [Header("Enemy Stats")]
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public UIEnemyHealthBar enemyHealthBar;

        GameObject player;
        NavMeshAgent agent;
        Animator anim;
        float timePassed;
        float newDestinationCD = 0.5f;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);

            if (timePassed >= attackCD)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    anim.SetTrigger("attack");
                    timePassed = 0;
                }
            }
            timePassed += Time.deltaTime;

            if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
            {
                newDestinationCD = 0.5f;
                agent.SetDestination(player.transform.position);
            }
            newDestinationCD -= Time.deltaTime;
            transform.LookAt(player.transform);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            enemyHealthBar.SetHealth(currentHealth);

            anim.SetTrigger("damage");
            //CameraShake.Instance.ShakeCamera(2f, 0.2f);

            if (currentHealth <= 0)
            {
                HandleDeath();
            }
            else
            {
                anim.SetTrigger("damage");
            }
        }

        private void HandleDeath()
        {
            currentHealth = 0;
            anim.SetTrigger("die");
            Destroy(gameObject);
        }

        public void StartDealDamage()
        {
            GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
        }

        public void EndDealDamage()
        {
            GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
        }

        public void HitVFX(Vector3 hitPosition)
        {
            GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
            Destroy(hit, 3f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, aggroRange);
        }
    }
}