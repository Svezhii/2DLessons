using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyWalk : MonoBehaviour
{
    //[SerializeField] private float _speed;
    //[SerializeField] private float radius;

    //private SpriteRenderer _spriteRenderer;

    //private void Update()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
    //    foreach (Collider2D collider in colliders)
    //    {
    //        if (collider.CompareTag("Player"))
    //        {
    //            // Ќайден игрок, начинаем преследование
    //            Vector3 direction = (collider.transform.position - transform.position).normalized;
    //            transform.position += direction * _speed * Time.deltaTime;
    //            if (transform.position.x < collider.transform.position.x)
    //            {
    //                _spriteRenderer.flipX = true;
    //            }
    //            else
    //            {
    //                _spriteRenderer.flipX = false;
    //            }
    //        }
    //    }
    //}


    [SerializeField] private float _speed;
    private Transform _target;

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;

        direction.y = 0f;

        transform.Translate(direction.normalized * _speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
