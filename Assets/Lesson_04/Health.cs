using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int Value;

    private int _maxValue;
    public int MaxValue => _maxValue;

    private void Start()
    {
        _maxValue = Value;
    }
}
