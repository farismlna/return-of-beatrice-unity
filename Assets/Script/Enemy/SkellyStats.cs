using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyStats : MonoBehaviour
{
    Animator anim;

    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public bool isDead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;

        anim.SetTrigger("damage");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        currentHealth = 0;
        anim.SetTrigger("die");
        isDead = true;
    }
}
