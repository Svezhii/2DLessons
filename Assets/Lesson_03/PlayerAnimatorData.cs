using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerAnimatorData : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();
    }

    public class Params
    {
        static public readonly int Speed = Animator.StringToHash(nameof(Speed));
        static public readonly int Attack = Animator.StringToHash(nameof(Attack));
        static public readonly int Hurt = Animator.StringToHash(nameof(Hurt));
    }

    private void Update()
    {
        _animator.SetFloat(Params.Speed, _playerMovement.Speed);

        if(_player.IsDamaged)
        {
            _animator.SetTrigger(Params.Hurt);

            _player.SetDamaged();
        }
    }
}
