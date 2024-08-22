using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDrop : MonoBehaviour, ICollectable
{
    [Header("Settings")]
    [SerializeField] private float _collectionSpeed;

    public void Collect(Transform player)
    {
        MoveTowardsCollector(player.position);
    }

    protected abstract void Collected();

    private void MoveTowardsCollector(Vector2 collector)
    {
        transform.position = Vector2.Lerp(transform.position, collector, _collectionSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Collected();
        }
    }
}
