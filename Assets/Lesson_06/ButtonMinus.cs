using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinus : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void OnButtonClick()
    {
        if (_health.Value > 0)
        _health.Value--;
    }
}
