using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private GameManager gameManager;
    private int baseDamage = 10;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Attack()
    {
        Collider[] _enemiesHit = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider _enemy in _enemiesHit)
        {
            //Debug.Log(_enemy.name);
            _enemy.GetComponent<I_Damageable>().TakeDamage(CalculateDamage());
        }
    }

    private int CalculateDamage()
    {
        int _raceStrength = gameManager.GetPlayerRace().GetStrength();
        int _classStrength = gameManager.GetPlayerClass().GetStrength();

        int _damageRangeModifier = 3;

        int _upperRange = baseDamage + _damageRangeModifier;
        int _lowerRange = baseDamage - _damageRangeModifier;

        int _damageRange = Random.Range(_lowerRange, _upperRange);

        int _playerDamage = _damageRange + _raceStrength + _classStrength;

        //Debug.Log("Player damage: " + _playerDamage);

        return _playerDamage;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) {  return; }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
