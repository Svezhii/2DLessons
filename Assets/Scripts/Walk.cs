using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private float _speed = 2;
    private float _direction;

    private void Update()
    {
        transform.Translate((_direction * _speed) * Time.deltaTime, 0, 0);
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
    }
}
