using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBehaviour : MonoBehaviour
{

    private CharacterController characterController;

    [Header("PlayerStats")]
    public float jumpHeight = 8f;
    private Rigidbody rb;
    
    [Header("GroundCheck")]
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    [SerializeField]private float moveVelocity;
    [SerializeField]private float gravity = 10f;
    
    
    public AudioClip marker;
    private AudioSource source;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Jump();
        PlayerMovement();
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
    }

    private void PlayerMovement()
    {
        Vector3 newPos = new Vector3(moveVelocity, jumpHeight, 0f);
        characterController.Move(newPos * Time.deltaTime);
    }

    private void Jump()
    {
        if(characterController.isGrounded)
        {
            jumpHeight = 0f;
        }

        jumpHeight -= gravity * Time.deltaTime;
    }
    
}
