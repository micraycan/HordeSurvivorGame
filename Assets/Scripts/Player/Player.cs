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
    /// Public facing method for player taking damage
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage, bool isCrit = false)
    {
        _health.TakeDamage(damage);
    }
}
