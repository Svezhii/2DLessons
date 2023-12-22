using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class EnemyOld : Character
{
    private Animator _animator;
    //private Health _health;
    static public readonly int Hurt = Animator.StringToHash(nameof(Hurt));

    private void Awake()
    {
        //_health = GetComponent<Health>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        Health.Value -= damage;

        _animator.SetTrigger(Hurt);

        if (Health.Value <= 0)
        {
            Die();
        }
    }

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}
