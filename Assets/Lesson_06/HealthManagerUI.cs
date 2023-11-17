using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManagerUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event UnityAction HealthChange;

    public void HealthMinus()
    {
        if (_health.Value > 0)
        _health.Value--;

        HealthChange?.Invoke();
    }

    public void HealthPlus()
    {
        if (_health.MaxValue > _health.Value)
            _health.Value++;

        HealthChange?.Invoke();
    }
}
