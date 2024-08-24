using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [Header("References")]
    private float _xpValue;
    private float _xpNeeded;
    private int _level;

    private void OnEnable() => GameActions.XpCollected += OnXpCollected;
    private void OnDestroy() => GameActions.XpCollected -= OnXpCollected;

    private void Start()
    {
        _level = 1;
        _xpValue = 0;
        _xpNeeded = _level * 10;
        GameActions.XpUpdated?.Invoke(_xpValue, _xpNeeded, _level);
    }

    private void OnXpCollected(XpOrb xpOrb)
    {
        float xpGain = AttributeManager.Instance.GetStat(Attribute.ExpGain);
        _xpValue += xpGain;
        
        if (_xpValue >= _xpNeeded)
        {
            float overleveledDiff = 
            _level++;
            _xpValue -= _xpNeeded;
            _xpNeeded = _level * 5;

            // LEVEL UP ACTION
        }

        GameActions.XpUpdated?.Invoke(_xpValue, _xpNeeded, _level);
    }
}
