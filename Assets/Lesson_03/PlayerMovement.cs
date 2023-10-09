using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    public float Speed { get; private set; }

    const float idle = 0;
    const float walk = 1;
    const float run = 2;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Walk();
        Run();
        Idle();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            Speed = 1;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            Speed = 1;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = false;

            Speed = 2;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = true;

            Speed = 2;
            transform.Translate(_speed  * Time.deltaTime * -1, 0, 0);
        }
    }

    private void Idle()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            Speed = 0;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Speed = 0;
        }
    }
}

