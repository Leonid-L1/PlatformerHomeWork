using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGetDamage : MonoBehaviour
{
    [SerializeField] private float _pushForce = 7;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;  
    private Vector3 _startPosition;
    private PlayerMovement _movement;

    public bool IsAbleToMove { get; private set; }

    private int _firstContanctPointIndex = 0;
    private float _animationTime = 0.7f;
    private int _maxHealth = 3;
    private int _health;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movement = GetComponent<PlayerMovement>(); 
        _startPosition = transform.position;
        _health = _maxHealth;
        IsAbleToMove = true;
    }
    private void Update()
    {   
        if(_health == 0)
        {
            transform.position = _startPosition;
            _rigidbody2D.velocity = Vector2.zero;
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

            if(point.normal.x == 1 || point.normal.x == -1)
            {
                _health--;
                Debug.Log("Health - " + _health);
                AnimateDamage(point);
                IsAbleToMove = false;
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
