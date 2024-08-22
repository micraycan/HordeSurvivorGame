using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement))]
public class Enemy : MonoBehaviour, IAttackable
{
    [Header("References")]
    private EnemyHealth _health;
    private EnemyMovement _movement;

    private void Start()
    {
        _health = GetComponent<EnemyHealth>();
        _movement = GetComponent<EnemyMovement>();
    }

    /// <summary>
    /// Public facing call for enemy taking damage
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="isCrit"></param>
    public void TakeDamage(int damage, bool isCrit = false)
    {
        _health.TakeDamage(damage);
        GameActions.EnemyDamaged?.Invoke(damage, transform, isCrit);
    }
}
