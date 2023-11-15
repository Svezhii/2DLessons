using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlus : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void OnButtonClick()
    {
        if (_health.MaxValue > _health.Value)
        _health.Value++;
    }
}
