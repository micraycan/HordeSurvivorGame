using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerMovement))]
public class Player : MonoBehaviour, IAttackable
{
    [Header("References")]
    private PlayerHealth _health;
    private PlayerMovement _movement;

    private void Start()
    {
        _health = GetComponent<PlayerHealth>();
        _movement = GetComponent<PlayerMovement>();
    }

    /// <summary>
    /// Public facing method for PlayerHealth.TakeDamage().
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1);

        foreach (Collider2D collider in colliders)
        {
            IAttackable attackable = collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                // attack
            }
        }
    }
}
