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

    private float verticalPos;
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
        CalculateVerticalPos();
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 newPos = new Vector3(moveVelocity, verticalPos, 0f);
        characterController.Move(newPos * Time.deltaTime);
    }

    private void CalculateVerticalPos()
    {
        if(characterController.isGrounded)
        {
            verticalPos = 0f;
        }

        verticalPos -= gravity * Time.deltaTime;
    }
    
}
