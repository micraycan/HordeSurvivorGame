using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    private int _maxHealth;
    private int _health;

    private void Start()
    {
        _maxHealth = (int)AttributeManager.Instance.GetStat(Attribute.MaxHealth);
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Min(_health, damage);
        _health -= damage;

        if (_health <= 0)
        {
            // player death action
        }

        GameActions.PlayerHealthChanged?.Invoke(_health);
    }
}
