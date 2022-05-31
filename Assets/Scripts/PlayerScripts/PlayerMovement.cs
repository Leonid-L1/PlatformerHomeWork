using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 8;
    [SerializeField] private float _speed = 6;

    public bool IsGrounded { get; private set; }

    private RaycastHit2D[] _results = new RaycastHit2D[1];
    private float _minGroundNormalY = 0.7f;
    private float _castDistance = 0.01f;
    private PlayerGetDamage _getDamage;
    private Rigidbody2D _rigidbody;

    private void Start()
    {        
        _rigidbody = GetComponent<Rigidbody2D>();   
        _getDamage = GetComponent<PlayerGetDamage>();
    }

    private void Update()
    {
        if (_getDamage.IsAbleToMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true && IsGrounded)
            {
                _rigidbody.velocity = Vector2.up * _jumpForce;
            }
            else if (Input.GetKey(KeyCode.D) == true)
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.A) == true)
            {
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        int count = _rigidbody.Cast(Vector2.down, _results, _castDistance);

        if (count > 0 && _results[0].normal.y >= _minGroundNormalY)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
