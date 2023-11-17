using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthManagerUI _healthManagerUI;

    private Slider _slider;
    private float _smoothSpeed = 5f;
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
        float targetValue = ((float)_health.Value / _health.MaxValue) * _oneHundredPercent;

        StartCoroutine(LerpHealthBar(targetValue));
    }

    private IEnumerator LerpHealthBar(float targetValue)
    {
        while (Mathf.Abs(_slider.value - targetValue) > 0.1f)
        {
            _slider.value = Mathf.Lerp(_slider.value, targetValue, _smoothSpeed * Time.deltaTime);
            yield return null;
        }

        _slider.value = targetValue;
    }
}
