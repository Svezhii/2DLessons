using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public Collider2D AttackCollider { get; private set; }
    [SerializeField] private float _damageDelayTime;

    private Coroutine _coroutine;
    public int Damage { get; private set; } = 1;
    private bool _canDamage = true;

    private void Start()
    {
        AttackCollider = GetComponent<Collider2D>();
        AttackCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canDamage)
        {
            AttackCollider.enabled = true;
            _canDamage = false;
            _coroutine = StartCoroutine(DamageDelayCoroutine());
        }
        else if(Input.GetMouseButtonUp(0))
        {
            AttackCollider.enabled = false;
        }
    }

    private IEnumerator DamageDelayCoroutine()
    {
        yield return new WaitForSeconds(_damageDelayTime);
        _canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(AttackCollider.enabled && collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if(enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
}
