using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private Health _health;
    public bool IsDamaged { get; private set; } = false;
    public event UnityAction HealthChange;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (_health.Value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health.Value -= damage;

        IsDamaged = true;

        HealthChange?.Invoke();
    }

    public void SetDamaged()
    {
        IsDamaged = false;
    }

    public void Healing(int healing)
    {
        if (_health.MaxValue - _health.Value >= healing)
        {
            _health.Value += healing;
        }
        else
        {
            _health.Value += _health.MaxValue - _health.Value;
        }

        HealthChange?.Invoke();
    }
}
