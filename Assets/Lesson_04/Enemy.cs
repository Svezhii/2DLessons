using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private Animator _animator;
    public int Health { get; private set; } = 10;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        _animator.SetTrigger("Hurt");

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
