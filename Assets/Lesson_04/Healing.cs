using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private int _healing = 10;
    private int _maxHP = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if(player.Health < _maxHP)
            {
                player.Healing(_healing);
            }
            else
            {
                player.Healing(_maxHP - player.Health);
            }
        }
    }
}
