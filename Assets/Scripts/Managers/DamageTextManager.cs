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
        _textPool = new ObjectPool<DamageText>(CreateFunction, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    private void OnEnemyDamaged(int damage, Transform enemy, bool isCrit)
    {
        DamageText textInstance = _textPool.Get();

        Vector3 spawnPosition = (Vector2)enemy.position + (Vector2.up / 2);
        textInstance.transform.position = spawnPosition;
        textInstance.Animate(damage, isCrit);

        LeanTween.delayedCall(1, () => _textPool.Release(textInstance));
    }

    private DamageText CreateFunction() => Instantiate(_textPrefab, transform);
    private void ActionOnGet(DamageText text) => text.gameObject.SetActive(true);
    private void ActionOnRelease(DamageText text) => text.gameObject.SetActive(false);
    private void ActionOnDestroy(DamageText text) => Destroy(text.gameObject);
}
