using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _movementPoint1;
    [SerializeField] private Transform _movementPoint2;

    private SpriteRenderer _renderer;
    private bool _isReach = true;
    private float _speed = 2f;
    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_isReach)
        {
            transform.position = Vector3.MoveTowards(transform.position, _movementPoint1.position, _speed * Time.deltaTime);

            if (transform.position.x == _movementPoint1.position.x)
            {                 
                _isReach = false;
                _renderer.flipX = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _movementPoint2.position, _speed * Time.deltaTime);

            if (transform.position.x == _movementPoint2.position.x)
            {
                _isReach = true;
                _renderer.flipX = false;    
            }
        }
    }
}
