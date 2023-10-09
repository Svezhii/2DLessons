using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider2D _attackCollider;
    private Animator _animator;
    public int Damage { get; private set; } = 1;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();

        _attackCollider.GetComponent<Collider2D>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play("Attack");
            _attackCollider.GetComponent<Collider2D>().enabled = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _attackCollider.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if(enemy != null)
            {
                Debug.Log("урон");
                enemy.TakeDamage(Damage);
            }
        }
    }
}
