using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [Header("References")]
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
}
