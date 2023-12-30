using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation
{
    private Animator _animator;
    
    public Animation(Animator animator)
    {
        _animator = animator;
    }

    public void Run()
    {
        _animator.SetBool("IsRun", Input.GetKey(KeyCode.LeftShift));
        _animator.SetFloat("Boost", Mathf.Abs(Move.GetSpeed()));
    }
}
