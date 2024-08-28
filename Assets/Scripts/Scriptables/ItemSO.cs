using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [Header("Base Settings")]
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
    [Tooltip("0-60 common, 61-80 uncommon, 81-95 rare, 96-100 legendary")]
    [SerializeField] protected float _rarity;

    public Sprite Sprite => _sprite;
    public string Name => _name;
    public string Description => _description;
    public float Rarity => _rarity;

    public abstract void Collect();
}
