using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    [SerializeField] private float _speed;

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
            _animator.SetFloat("Speed", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("Speed", 0);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = false;

            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetFloat("Speed", 2);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_speed  * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", 2);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}
