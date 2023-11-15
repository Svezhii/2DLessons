using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;
    private int _oneHundredPercent = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = ((float)_health.Value / _health.MaxValue) * _oneHundredPercent;
    }
}
