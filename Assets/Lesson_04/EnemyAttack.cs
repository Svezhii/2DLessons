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
    private bool _canDamage = true;
    private Coroutine _coroutine;
    private int Damage = 1;
    static public readonly int Attack = Animator.StringToHash(nameof(Attack));

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _attackCollider = GetComponent<Collider2D>();
        _attackCollider.enabled = false;
    }

    private void Update()
    {
        var hitsLeft = Physics2D.RaycastAll(transform.position, Vector2.left, _radius);
        var hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right, _radius);

        var hits = new RaycastHit2D[hitsLeft.Length + hitsRight.Length];
        hitsLeft.CopyTo(hits, 0);
        hitsRight.CopyTo(hits, hitsLeft.Length);

        var objectsWithComponent = hits.FirstOrDefault(hit => hit.collider.TryGetComponent<Player>(out Player player));

        if (objectsWithComponent && _canDamage)
        {
            _animator.SetTrigger(Attack);
            _coroutine = StartCoroutine(AnimationDelayCoroutine());
            _canDamage = false;
            _coroutine = StartCoroutine(DamageDelayCoroutine());
            _attackCollider.enabled = false;
        }
    }

    private IEnumerator AnimationDelayCoroutine()
    {
        yield return new WaitForSeconds(_damageDelayTime + 0.2f);
        _attackCollider.enabled = true;
    }

    private IEnumerator DamageDelayCoroutine()
    {
        yield return new WaitForSeconds(_damageDelayTime);
        _canDamage = true;
        _attackCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_attackCollider.enabled && collision.TryGetComponent<Player>(out Player player))
        {
            if (player != null)
            {
                player.TakeDamage(Damage);
            }
        }
    }
}
