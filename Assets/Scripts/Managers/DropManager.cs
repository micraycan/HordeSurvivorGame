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
        _xpPool = Utils.CreateObjectPool(
                () => Instantiate(_xpPrefab, transform),
                xpOrb => xpOrb.gameObject.SetActive(true),
                xpOrb => xpOrb.gameObject.SetActive(false),
                xpOrb => Destroy(xpOrb.gameObject)
            );
    }

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
