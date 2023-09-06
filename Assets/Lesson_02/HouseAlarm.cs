using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _fadingController;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _recoveryRate = 0.1f;
    private bool isEnemyInside = false;

    private void Update()
    {
        if(isEnemyInside)
        {
            float volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;
        }
        else
        {
            float volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _recoveryRate * Time.deltaTime);
            _audioSource.volume = volume;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            isEnemyInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            isEnemyInside = false;
        }
    }
}
