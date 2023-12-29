using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HealthDrainAbility : MonoBehaviour
{
    [SerializeField]private Button _abilityButton;
    [SerializeField]private Player _player;

    private float _abilityDuration = 1;
    private bool _isAbilityActive = false;
    private Enemy _enemy;

    private void Start()
    {
        _abilityButton.interactable = false;
    }

    private void OnEnable()
    {
        _abilityButton.onClick.AddListener(ButtonClick);
    }

    private void OnDisable()
    {
        _abilityButton.onClick.RemoveListener(ButtonClick);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemy = enemy;
            _abilityButton.interactable = true;
            _isAbilityActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemy = enemy;
            _abilityButton.interactable = false;
            _isAbilityActive = false;
        }
    }

    private IEnumerator HealthSuck(Enemy enemy)
    {
        var waitForSeconds = new WaitForSecondsRealtime(_abilityDuration);

        while (_isAbilityActive)
        {
            enemy.TakeDamage(1);
            _player.Healing(1);

            yield return waitForSeconds;
        }
    }

    private void ButtonClick()
    {
        if(_enemy != null)
        {
            StartCoroutine(HealthSuck(_enemy));
        }
    }
}
