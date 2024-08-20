using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth _health;
    private PlayerMovement _movement;

    private void Awake()
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
}
