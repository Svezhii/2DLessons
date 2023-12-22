using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public abstract class Character : MonoBehaviour
{
    protected Health Health;
    public event UnityAction HealthChange;

    private void Awake()
    {
        Health = GetComponent<Health>();
    }

    public abstract void TakeDamage(int damage);

    protected void Die()
    {
        if (Health.Value <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void Call()
    {
        HealthChange?.Invoke();
    }
}
