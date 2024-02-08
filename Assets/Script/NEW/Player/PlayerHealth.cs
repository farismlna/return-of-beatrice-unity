using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    public float currentHealth;

    GameObject enemy;
    Animator anim;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemy = GameObject.FindWithTag("Enemy");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //print("take damage");
        anim.SetTrigger("GetHit");

        if (currentHealth <= 0)
        {
            anim.SetTrigger("IsDeath");
            Invoke(nameof(DestroyPlayer), 2);
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision ObjectYangMenyentuhPlayer)
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            if (ObjectYangMenyentuhPlayer.gameObject.CompareTag("CanDamagePlayer"))
            {
                TakeDamage(1);
                print("take damage");
            }
        }
    }
}
