using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DamageTextManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DamageText _textPrefab;
    private ObjectPool<DamageText> _textPool;

    private void OnEnable() => GameActions.EnemyDamaged += OnEnemyDamaged;
    private void OnDestroy() => GameActions.EnemyDamaged += OnEnemyDamaged;

    private void Start()
    {
        _textPool = Utils.CreateObjectPool(
                () => Instantiate(_textPrefab, transform),
                text => text.gameObject.SetActive(true),
                text => text.gameObject.SetActive(false),
                text => Destroy(text.gameObject)
            );
    }

    private void OnEnemyDamaged(int damage, Transform enemy, bool isCrit)
    {
        DamageText textInstance = _textPool.Get();

        Vector3 spawnPosition = (Vector2)enemy.position + (Vector2.up / 2);
        textInstance.transform.position = spawnPosition;
        textInstance.Animate(damage, isCrit);

        LeanTween.delayedCall(1, () => _textPool.Release(textInstance));
    }
}
