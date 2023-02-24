using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour, I_Damageable
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInteractions player;

    [SerializeField] private float basehealth = 100f;

    private CapsuleCollider myCollider;
    private float health;
    private bool isAlive;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform moveLocation;

    private void Start()
    {
        health = basehealth;
        isAlive = true;
        player = FindObjectOfType<PlayerInteractions>();
        myCollider = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Move(moveLocation);
    }

    private void Move(Transform _moveLocation)
    {
        navMeshAgent.Move(_moveLocation.position);

        if (Vector3.Distance(_moveLocation.position, transform.position) > 0.3f)
        {
            animator.SetFloat("Movement", 1, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Movement", 0, 0.1f, Time.deltaTime);
        }
    }

    public void TakeDamage(int _damageTaken)
    {
        animator.SetTrigger("TakeDamage");
        health -= _damageTaken;
        
        if (health <= 0 && isAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;

        animator.SetTrigger("Die");
        myCollider.enabled = false;

        Quest _playerQuest = player.GetCurrentQuest();

        if (_playerQuest != null)
        {
            _playerQuest.goal.ProgressGoal();
            _playerQuest.CheckGoalProgress();
        }
    }

    public float GetHealth()
    {
        return health;
    }
}