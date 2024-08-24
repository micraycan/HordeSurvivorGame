using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpSlider : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void OnEnable() => GameActions.XpUpdated += OnXpUpdated;
    private void OnDestroy() => GameActions.XpUpdated -= OnXpUpdated;

    private void OnXpUpdated(float xpValue, float xpNeeded, int level)
    {
        _slider.value = xpValue / xpNeeded;
        _levelText.text = $"Lvl {level}";
    }
}
