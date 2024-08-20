using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _maxHealth;
    private int _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Min(_health, damage);
        _health -= damage;

        if (_health <= 0)
        {
            // TODO: trigger event for onEnemyDeath
        }

        Debug.Log($"Enemy takes {damage} damage, health = {_health}");
    }
}
