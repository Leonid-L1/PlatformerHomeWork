using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class SetAnimation : MonoBehaviour
{
    private const string _isRun = "isRun";
    private SpriteRenderer _renderer;
    private Animator _animator;
    private bool _isRunning;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {          
        if (Input.GetKey(KeyCode.D) == true)
        {
            _renderer.flipX = false;
            _isRunning = true;
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            _renderer.flipX = true;
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
        _animator.SetBool(_isRun, _isRunning);
    }
}
