using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] public int Health { get; private set; } = 20;

    public bool IsDamaged { get; private set; } = false;

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        Debug.Log(Health);

        IsDamaged = true;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void SetDamaged()
    {
        IsDamaged = false;
    }

    public void Healing(int healing)
    {
        Health += healing;
    }
}
