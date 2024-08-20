using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    private Transform _player;
    private Rigidbody2D _rb;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _player = GameManager.Instance.Player.transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * _moveSpeed;
    }
}
