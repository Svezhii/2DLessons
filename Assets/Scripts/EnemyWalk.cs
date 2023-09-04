using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyWalk : MonoBehaviour
{
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
