using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Player _player;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.HealthChange += ChangeText;
    }

    private void OnDisable()
    {
        _player.HealthChange -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = ($"{_health.Value}/{_health.MaxValue}");
    }
}
