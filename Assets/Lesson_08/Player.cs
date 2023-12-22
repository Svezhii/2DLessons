using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    public bool IsDamaged { get; private set; } = false;

    private void Update()
    {
        Die();
    }

    public override void TakeDamage(int damage)
    {
        Health.Value -= damage;

        IsDamaged = true;

        Call();
    }

    public void SetDamaged()
    {
        IsDamaged = false;
    }

    public void Healing(int healing)
    {
        if (Health.MaxValue - Health.Value >= healing)
        {
            Health.Value += healing;
        }
        else
        {
            Health.Value += Health.MaxValue - Health.Value;
        }

        Call();
    }
}
