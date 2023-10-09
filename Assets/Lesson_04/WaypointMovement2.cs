using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WaypointMovement2 : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;
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
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer < _radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, (_speed + 2) * Time.deltaTime);

            FlipCharacter(_player);
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
        if (transform.position.x < target.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
