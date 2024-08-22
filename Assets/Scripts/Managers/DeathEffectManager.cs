using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DeathEffectManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DeathEffect _deathPrefab;
    private ObjectPool<DeathEffect> _objPool;

    private void OnEnable() => GameActions.EnemyDeath += OnEnemyDeath;
    private void OnDestroy() => GameActions.EnemyDeath -= OnEnemyDeath;

    private void Start()
    {
        _objPool = Utils.CreateObjectPool(
            () => Instantiate(_deathPrefab, transform),
            fx => fx.gameObject.SetActive(true),
            fx => fx.gameObject.SetActive(false),
            fx => Destroy(fx.gameObject)
            );
    }

    private void OnEnemyDeath(Vector2 enemyPos)
    {
        DeathEffect fxInstance = _objPool.Get();
        fxInstance.transform.position = enemyPos;
        fxInstance.Animate();

        LeanTween.delayedCall(1, () => _objPool.Release(fxInstance));
    }
}
