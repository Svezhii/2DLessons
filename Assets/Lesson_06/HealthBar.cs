using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthManagerUI _healthManagerUI;

    private Slider _slider;
    private int _oneHundredPercent = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _healthManagerUI.HealthChange += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _healthManagerUI.HealthChange -= ChangeHealthBar;
    }

    private void ChangeHealthBar()
    {
        _slider.value = ((float)_health.Value / _health.MaxValue) * _oneHundredPercent;
    }
}
