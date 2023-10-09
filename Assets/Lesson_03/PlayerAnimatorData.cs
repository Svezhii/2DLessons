using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimatorData : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public class Params
    {
        static public readonly int Speed = Animator.StringToHash(nameof(Speed));
        static public readonly int Attack = Animator.StringToHash(nameof(Attack));
    }

    private void Update()
    {
        _animator.SetFloat(Params.Speed, _playerMovement.Speed);
    }
}
