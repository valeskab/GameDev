using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBehaviour : MonoBehaviour
{
    [Header("PlayerStats")]
    public float jumpHeight = 8f;
    private Rigidbody rb;
    
    [Header("GroundCheck")]
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private float moveVelocity;
    
    
    public AudioClip marker;
    private AudioSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            source.PlayOneShot(marker, 1.0f);
        }
    }
    
}
