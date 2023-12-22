using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyold : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Playerold player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
