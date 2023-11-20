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
    [SerializeField] private Player _player;

    private Slider _slider;
    private int _oneHundredPercent = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChange += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _player.HealthChange -= ChangeHealthBar;
    }

    private void ChangeHealthBar()
    {
        _slider.value = ((float)_health.Value / _health.MaxValue) * _oneHundredPercent;
    }
}
