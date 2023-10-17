using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private Health _health;
    static public readonly int Hurt = Animator.StringToHash(nameof(Hurt));

    private void Start()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health.Count -= damage;

        _animator.SetTrigger(Hurt);

        if (_health.Count <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
