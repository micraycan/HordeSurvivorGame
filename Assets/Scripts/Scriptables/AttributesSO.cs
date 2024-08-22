using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attribute Data", menuName = "Scriptable Objects/Attribute Data")]
public class AttributesSO : SerializedScriptableObject
{
    [Header("Attributes")]
    [OdinSerialize] private AttributeDictionary attributes;

    public float GetValue(Attribute attribute)
    {
        if (attributes.ContainsKey(attribute))
        {
            return attributes[attribute];
        }
        else
        {
            Debug.LogWarning($"Attribute {attribute} not found in {name}.");
            return 0f;
        }
    }
}

[Serializable]
public class AttributeDictionary : Dictionary<Attribute, float>
{
    public AttributeDictionary()
    {
        this[Attribute.MaxHealth] = 0;
        this[Attribute.Speed] = 0;
        this[Attribute.Damage] = 0;
        this[Attribute.CritChance] = 0;
        this[Attribute.PickupRadius] = 0;
    }
}