using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    const int idle = 0;
    const int walk = 1;
    const int run = 2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Walk();
        Run();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", walk);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("Speed", idle);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", walk);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("Speed", idle);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = false;

            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", run);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("Speed", idle);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_speed  * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", run);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("Speed", idle);
        }
    }
}
