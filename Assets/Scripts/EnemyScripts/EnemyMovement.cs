using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

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
            if (PointMove(_movementPoint1))
            {                 
                _renderer.flipX = true;
                _isReach = false;
            }
        }
        else
        {
            if (PointMove(_movementPoint2))
            {
                _renderer.flipX = false;    
                _isReach = true;
            }
        }
    }
    private bool PointMove(Transform movementPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, movementPoint.position, _speed * Time.deltaTime);

        if(transform.position.x == movementPoint.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
