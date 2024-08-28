using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class UpgradeSlots : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Upgrade[] _upgrade;

    private List<ItemSO> GenerateItems(int count = 3)
    {
        float luckModifier = AttributeManager.Instance.GetStat(Attribute.Luck);

        List<ItemSO> available = GameManager.Instance.Upgrades.ToList();
        List<ItemSO> result = new List<ItemSO>();

        while (result.Count < count && available.Count > 0)
        {
            ItemSO selected = available[Random.Range(0, available.Count)];
            float roll = (Random.value * 100) * luckModifier;

            if (roll > selected.Rarity)
            {
                result.Add(selected);
                available.Remove(selected);
            }
        }

        return result;
    }
}

[Serializable]
public class Upgrade
{
    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Description { get; private set; }
    [field: SerializeField] public Image Image { get; private set; }
}
