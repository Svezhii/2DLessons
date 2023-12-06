using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Collider2D _attackCollider;
    [SerializeField] private float _damageDelayTime;

    private Animator _animator;
    private bool _canAttack = true;
    private Coroutine _coroutine;
    private int Damage = 1;
    private float _animationDelay = 0.2f;
    static public readonly int Attack = Animator.StringToHash(nameof(Attack));

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _attackCollider = GetComponent<Collider2D>();
        _attackCollider.enabled = false;
    }

    private void Update()
    {
        var player = FindPlayer();

        Hit(player);
    }

    private void Hit(RaycastHit2D player)
    {
        if (player && _canAttack)
        {
            _animator.SetTrigger(Attack);
            _coroutine = StartCoroutine(DamageDelayCoroutine());
        }
    }

    private RaycastHit2D FindPlayer()
    {
        var hitsLeft = Physics2D.RaycastAll(transform.position, Vector2.left, _radius);
        var hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right, _radius);

        var hits = new RaycastHit2D[hitsLeft.Length + hitsRight.Length];
        hitsLeft.CopyTo(hits, 0);
        hitsRight.CopyTo(hits, hitsLeft.Length);

        return hits.FirstOrDefault(hit => hit.collider.TryGetComponent<PlayerOld>(out PlayerOld player));
    }

    private IEnumerator DamageDelayCoroutine()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_animationDelay);
        _attackCollider.enabled = true;
        yield return new WaitForSeconds(_damageDelayTime);
        _canAttack = true;
        _attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_attackCollider.enabled && collision.TryGetComponent<PlayerOld>(out PlayerOld player))
        {
            if (player != null)
            {
                player.TakeDamage(Damage);
            }
        }
    }
}
