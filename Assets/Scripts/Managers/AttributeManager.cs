using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : Singleton<AttributeManager>
{
    [Header("References")]
    [SerializeField] private AttributesSO baseAttributes;
    [SerializeField] private AttributesSO flatBonus;
    [SerializeField] private AttributesSO multBonus;

    public float GetStat(Attribute attribute)
    {
        float baseValue = baseAttributes.GetValue(attribute);
        float flatValue = flatBonus.GetValue(attribute);
        float multValue = multBonus.GetValue(attribute);

        return (baseValue + flatValue) * (1 + multValue / 100);
    }
}
