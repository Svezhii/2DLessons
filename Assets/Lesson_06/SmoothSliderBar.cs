using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;
    private float smoothSpeed = 5f;
    private int _oneHundredPercent = 100;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, ((float)_health.Value / _health.MaxValue) * _oneHundredPercent, Time.deltaTime * smoothSpeed);
    }
}
