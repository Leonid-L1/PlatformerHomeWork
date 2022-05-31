using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerGetDamage : MonoBehaviour
{
    [SerializeField] private float _pushForce = 7;

    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _movement;
    private Rigidbody2D _rigidbody2D;  
    private Vector3 _startPosition;

    public bool IsAbleToMove { get; private set; }

    private int _firstContanctPointIndex = 0;
    private float _animationTime = 0.7f;
    private int _maxHealth = 3;
    private int _health;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _movement = GetComponent<PlayerMovement>(); 
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _health = _maxHealth;
        IsAbleToMove = true;
    }

    private void Update()
    {   
        if(_health == 0)
        {
            _rigidbody2D.velocity = Vector2.zero;
            transform.position = _startPosition;
            _health = _maxHealth;
        }
    }

    private void FixedUpdate()
    {
        if(IsAbleToMove != _movement.IsGrounded)
        {
            IsAbleToMove = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        var enemy = collision.collider.GetComponent<EnemyDestruction>();

        if (enemy != null)
        {
            ContactPoint2D point = collision.GetContact(_firstContanctPointIndex);

            if(point.normal.x == Vector2.right.x || point.normal.x == Vector2.left.x)
            {
                AnimateDamage(point);
                IsAbleToMove = false;
                _health--;
            }
        }
    }

    private void AnimateDamage(ContactPoint2D point)
    {
        Vector2 pushDirection = new Vector2(point.normal.x, Vector2.up.y);
        _rigidbody2D.velocity += pushDirection * _pushForce;
        _spriteRenderer.DOColor(Color.red, _animationTime).From();
    }
}
