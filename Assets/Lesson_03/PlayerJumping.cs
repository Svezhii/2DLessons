using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isGround;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider.TryGetComponent(out Player player))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.otherCollider.TryGetComponent(out Player player))
        {
            _isGround = false;
        }
    }

}
