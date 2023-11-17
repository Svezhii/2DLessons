using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthManagerUI _healthManagerUI;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _healthManagerUI.HealthChange += ChangeText;
    }

    private void OnDisable()
    {
        _healthManagerUI.HealthChange -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = ($"{_health.Value}/{_health.MaxValue}");
    }
}
