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
        ChangeAnim("IdleBell");
    }
    public void ShowRunAnim()
    {
        ChangeAnim("runBelle");
    }
    public void ShowJumpAnim()
    {
        ChangeAnim("jumpBelle");
    }
    public void ShowSlideAnim()
    {
        ChangeAnim("slideBell");
    }
}
