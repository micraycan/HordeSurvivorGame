using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemPickup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask _collectableMask;
    private float _pickupRadius;

    private void Start()
    {
        _pickupRadius = AttributeManager.Instance.GetStat(Attribute.PickupRadius);
    }

    private void Update()
    {
        TryPickup();
    }

    private void TryPickup()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _pickupRadius, _collectableMask);

        foreach (Collider2D collider in colliders)
        {
            if (collider != null)
            {
                collider.GetComponent<ICollectable>().Collect(transform);
            }
        }
    }
}
