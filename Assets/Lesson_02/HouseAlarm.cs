using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    public bool IsEnemyEntered { get; private set; } = false;
    public bool IsEnemyExited { get; private set; } = false;
    public bool IsEnemyInside { get; private set; } = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            IsEnemyEntered = true;
            IsEnemyInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsEnemyExited = true;
            IsEnemyInside = false;
        }
    }

    public void SwitchFlags()
    {
        IsEnemyEntered = false;
        IsEnemyExited = false;
    }
}
