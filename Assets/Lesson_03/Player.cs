using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour 
{
    private Health _health;
    public bool IsDamaged { get; private set; } = false;
    private int _maxHP = 20;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health.Count -= damage;

        IsDamaged = true;

        if (_health.Count <= 0)
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
        if (_health.Count <= healing)
        {
            _health.Count += healing;
        }
        else
        {
            _health.Count += _maxHP - _health.Count;
        }
    }
}
