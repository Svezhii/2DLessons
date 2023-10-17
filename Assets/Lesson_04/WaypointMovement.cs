using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(SpriteRenderer))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Transform[] _points;
    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        var hitsLeft = Physics2D.RaycastAll(transform.position, Vector2.left, _radius);
        var hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right, _radius);

        var hits = new RaycastHit2D[hitsLeft.Length + hitsRight.Length];
        hitsLeft.CopyTo(hits, 0);
        hitsRight.CopyTo(hits, hitsLeft.Length);

        var objectsWithComponent = hits.FirstOrDefault(hit => hit.collider.TryGetComponent<Player>(out Player player));

        if (objectsWithComponent)
        {
            transform.position = Vector3.MoveTowards(transform.position, objectsWithComponent.transform.position, (_speed + 2) * Time.deltaTime);

            FlipCharacter(objectsWithComponent.transform);
        }
        else
        {
            Transform target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }

            FlipCharacter(target);
        }
    }

    private void FlipCharacter(Transform target)
    {
        _spriteRenderer.flipX = transform.position.x < target.position.x;
    }
}
