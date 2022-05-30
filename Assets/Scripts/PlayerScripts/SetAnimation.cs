using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Animator _animator;
    private bool _isRunning;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SetRunBool());
    }
    
    private void Update()
    {          
        if (Input.GetKey(KeyCode.D) == true)
        {
            _isRunning = true;
            _renderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            _isRunning = true;
            _renderer.flipX = true;
        }
        else
        {
            _isRunning = false;
        }       
    }
    private IEnumerator SetRunBool()  
    {   
        while (true)
        {
            _animator.SetBool("isRun", _isRunning);
            yield return null;
        } 
    }
}
