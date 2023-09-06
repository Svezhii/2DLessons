using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[RequireComponent(typeof(VolumeController))]
public class HouseAlarm : MonoBehaviour
{
    private VolumeController _volumeController;
    private Coroutine _fadeCorutine;
    private bool IsEnemyInsaid = false;

    private void Start()
    {
        _volumeController = GetComponent<VolumeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            IsEnemyInsaid = true;

            if (_fadeCorutine != null)
            {
                StopCoroutine(_fadeCorutine);
            }

            _fadeCorutine = StartCoroutine(_volumeController.FadeController(IsEnemyInsaid));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsEnemyInsaid = false;

            if (_fadeCorutine != null)
            {
                StopCoroutine(_fadeCorutine);
            }

            _fadeCorutine = StartCoroutine(_volumeController.FadeController(IsEnemyInsaid));
        }
    }
}
