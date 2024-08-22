using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;

    [Header("Settings")]
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Vector2 _attackSize;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private int _weaponDamage;
    private float _lastAttackTime;

    private void Update()
    {
        AuttoAttack();
    }

    private void AuttoAttack()
    {
        if (Utils.IsReady(ref _lastAttackTime, _attackCooldown))
        {
            Attack();
        }
    }

    private void Attack()
    {
        _animator.Play("Attack");
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, _attackSize, transform.rotation.z, _enemyMask);

        foreach (Collider2D collider in colliders)
        {
            IAttackable attackable = collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                int damage = CalculateWeaponDamage(out bool isCrit);
                attackable.TakeDamage(damage, isCrit);
            }
        }
    }
    private void StopAttack()
    {
        _animator.Play("Idle");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position, _attackSize);
    }

    private int CalculateWeaponDamage(out bool isCrit)
    {
        float critStat = AttributeManager.Instance.GetStat(Attribute.CritChance);
        isCrit = Random.value <= (critStat / 100);
        int damageStat = (int)AttributeManager.Instance.GetStat(Attribute.Damage);
        return isCrit ? damageStat * 2 : damageStat;
    }
}
