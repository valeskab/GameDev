using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    private Animator animator;
    private string currentAnim;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void ChangeAnim(string newAnim)
    {
        if (currentAnim == newAnim)
        {
            return;
        }
        animator.Play(newAnim);
        currentAnim = newAnim;
    }

    public void ShowIdleAnim()
    {
        ChangeAnim("Idle");
    }
    public void ShowRunAnim()
    {
        ChangeAnim("Run");
    }
    public void ShowJumpAnim()
    {
        ChangeAnim("Jump");
    }
    public void ShowCrouchAnim()
    {
        ChangeAnim("Crouch");
    }
}
