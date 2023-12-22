using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : Character
{
    private Animator _animator;
    static public readonly int Hurt = Animator.StringToHash(nameof(Hurt));

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        Health.Value -= damage;

        _animator.SetTrigger(Hurt);

        Call();

        if (Health.Value <= 0)
        {
            Die();
        }
    }
}
