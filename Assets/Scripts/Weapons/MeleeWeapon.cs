using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;

    [Header("Settings")]
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackCooldown;
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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius);

        foreach (Collider2D collider in colliders)
        {
            IAttackable attackable = collider.GetComponent<IAttackable>();
            if (attackable != null)
            {
                attackable.TakeDamage(1);
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
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }

}
