using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshPro _damageText;
    [SerializeField] private Animator _animator;
    [SerializeField] private Color _critColor;

    public void Animate(int damage, bool isCrit)
    {
        _damageText.color = isCrit ? _critColor : Color.white;
        _damageText.text = damage.ToString();
        _animator.Play("Active");
    }

    private void StopAnimation()
    {
        _animator.Play("Idle");
    }
}
