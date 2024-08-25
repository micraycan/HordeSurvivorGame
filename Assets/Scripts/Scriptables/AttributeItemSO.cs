using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attribute Upgrade", menuName = "Scriptable Objects/Attribute Upgrade")]
public class AttributeItemSO : ItemSO, IUpgrade
{
    [Header("Settings")]
    [SerializeField] private Attribute _attribute;
    [SerializeField] private float _value;
    [SerializeField] private bool _isMult;
}
