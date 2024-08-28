using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlots : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Upgrade[] _upgrade;

    private ItemSO[] GenerateItems()
    {
        return null;
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
