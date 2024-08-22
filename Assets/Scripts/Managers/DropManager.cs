using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DropManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private XpOrb _xpPrefab;
    private ObjectPool<XpOrb> _xpPool;

    private void OnEnable()
    {
        GameActions.EnemyDeath += OnEnemyDeath;
        GameActions.XpCollected += OnXpCollected;
    }

    private void OnDestroy()
    {
        GameActions.EnemyDeath -= OnEnemyDeath;
        GameActions.XpCollected -= OnXpCollected;
    }

    private void Start()
    {
        _xpPool = new ObjectPool<XpOrb>(CreateFunction, ActionOnGet, ActionOnRelease, ActionOnDestroy);
    }

    private XpOrb CreateFunction() => Instantiate(_xpPrefab, transform);
    private void ActionOnGet(XpOrb xpOrb) => xpOrb.gameObject.SetActive(true);
    private void ActionOnRelease(XpOrb xpOrb) => xpOrb.gameObject.SetActive(false);
    private void ActionOnDestroy(XpOrb xpOrb) => Destroy(xpOrb);

    private void OnEnemyDeath(Vector2 enemyPos)
    {
        ItemDrop drop = _xpPool.Get();
        drop.transform.position = enemyPos;
    }

    private void OnXpCollected(XpOrb xpOrb)
    {
        _xpPool.Release(xpOrb);
    }
}
