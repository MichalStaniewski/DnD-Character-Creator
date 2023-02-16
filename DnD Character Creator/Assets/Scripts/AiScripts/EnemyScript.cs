using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float basehealth = 100f;
    private float health;

    private void Start()
    {
        health = basehealth;
    }

    public void TakeDamage(int _damageTaken)
    {
        animator.SetTrigger("TakeDamage");
        health -= _damageTaken;
        
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
    }

    public float GetHealth()
    {
        return health;
    }
}
