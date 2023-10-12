using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider2D _attackCollider;
    [SerializeField] private float _damageDelayTime;

    private Animator _animator;
    private Coroutine _coroutine;
    public int Damage { get; private set; } = 1;
    private bool _canDamage = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _attackCollider = GetComponent<Collider2D>();
        _attackCollider.GetComponent<Collider2D>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canDamage)
        {
            _animator.Play("Attack");
            _attackCollider.GetComponent<Collider2D>().enabled = true;
            _canDamage = false;
            _coroutine = StartCoroutine(DamageDelayCoroutine());
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _attackCollider.GetComponent<Collider2D>().enabled = false;
        }
    }

    private IEnumerator DamageDelayCoroutine()
    {
        yield return new WaitForSeconds(_damageDelayTime);
        _canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_attackCollider.enabled && collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if(enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
}
