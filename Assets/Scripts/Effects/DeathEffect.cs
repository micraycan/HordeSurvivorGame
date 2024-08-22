using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;

    public void Animate()
    {
        _animator.Play("Active");
    }

    private void StopAnimation()
    {
        _animator.Play("Idle");
    }
}
