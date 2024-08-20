using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackCooldown;
    private float _lastAttackTime;

    private void Start()
    {
        _lastAttackTime = Time.time;
    }

    private void Update()
    {
        TryAttacking();
    }

    private void TryAttacking()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _attackRadius, _playerMask);

        // player in melee range
        if (collider != null)
        {
            if (Utils.IsReady(ref _lastAttackTime, _attackCooldown))
            {
                IAttackable attackable = collider.GetComponent<IAttackable>();
                attackable.TakeDamage(1);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
