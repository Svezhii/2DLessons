using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    private VolumeControlling _volumeController;
    public bool IsEnemyInside { get; private set; } = false;

    private void Start()
    {
        _volumeController = GetComponent<VolumeControlling>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            IsEnemyInside = true;

            _volumeController.StartVolumeChangingCorutine();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsEnemyInside = false;

            _volumeController.StartVolumeChangingCorutine();
        }
    }
}
