using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = ($"{_health.Value}/{_health.MaxValue}");
    }
}
