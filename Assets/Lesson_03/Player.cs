using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour 
{
    private Health _health;
    public bool IsDamaged { get; private set; } = false;
    private int _maxHP = 20;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health.Value -= damage;

        IsDamaged = true;

        if (_health.Value <= 0)
        {
            Die();
        }
    }

    public void SetDamaged()
    {
        IsDamaged = false;
    }

    public void Healing(int healing)
    {
        if (_health.Value <= healing)
        {
            _health.Value += healing;
        }
        else
        {
            _health.Value += _maxHP - _health.Value;
        }
    }
}
