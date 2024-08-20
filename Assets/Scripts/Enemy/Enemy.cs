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

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
