using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Character _character;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = ($"{_health.Value}/{_health.Value}");
    }

    private void OnEnable()
    {
        _character.HealthChange += ChangeText;
    }

    private void OnDisable()
    {
        _character.HealthChange -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = ($"{_health.Value}/{_health.MaxValue}");
    }
}
