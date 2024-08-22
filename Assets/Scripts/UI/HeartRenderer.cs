using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRenderer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    [SerializeField] private GameObject _heartSlotPrefab;
    private int _health;
    private int _maxHealth;

    private void OnEnable() => GameActions.PlayerHealthChanged += OnPlayerHealthChanged;
    private void OnDisable() => GameActions.PlayerHealthChanged -= OnPlayerHealthChanged;

    private void Start()
    {
        InitializeHeartContainers();
    }

    private void OnPlayerHealthChanged(int health)
    {
        _health = health;
        RenderHeartContainers();
    }

    private void RenderHeartContainers()
    {
        _maxHealth = (int)AttributeManager.Instance.GetStat(Attribute.MaxHealth);
        int maxContainers = Mathf.CeilToInt(_maxHealth / 2f);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxContainers; i++)
        {
            GameObject heartContainer = Instantiate(_heartSlotPrefab, transform);
            Image heartImage = heartContainer.GetComponent<Image>();

            if (_health >= 2 * (i + 1)) { heartImage.sprite = _sprites[2]; }
            else if (_health == (2 * i) + 1) { heartImage.sprite = _sprites[1]; }
            else { heartImage.sprite = _sprites[0]; }
        }
    }

    private void InitializeHeartContainers()
    {
        _maxHealth = (int)AttributeManager.Instance.GetStat(Attribute.MaxHealth);
        _health = _maxHealth;
        RenderHeartContainers();
    }
}
