using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DirectionInput
{
    Null,
    Jump,
    Slide
}
public class PlayerControllerBehaviour : MonoBehaviour
{
    private CharacterController characterController;

    private PlayerAnims playerAnims;

    [Header("PlayerStats")]
    private Rigidbody rb;
    
    [Header("GroundCheck")]

    private float verticalPos;
    [SerializeField]private float moveVelocity;
    private float jumpHeight = 14.5f;
    [SerializeField]private float gravity = 20f;

    private DirectionInput directionInput;
    private Coroutine coroutineSlide;

    private float controllerRadius;
    private float controllerHeight;
    private float controllerPosY;

    public bool IsJumping { get; private set; }

    public bool IsSliding { get; private set; }
    
    public AudioClip marker;
    private AudioSource source;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerAnims = GetComponent<PlayerAnims>();
    }

    private void Start()
    {
        controllerRadius = characterController.radius;
        controllerHeight = characterController.height;
        controllerPosY = characterController.center.y;
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState == GameStates.Start || GameManager.Instance.CurrentState == GameStates.GameOver)
        {
            return;
        }
        InputDetection();
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
            IsJumping = false;
            verticalPos = 0f;

            if (IsSliding == false && IsJumping == false)
            {
                 playerAnims.ShowRunAnim();
            }

            if (directionInput == DirectionInput.Jump)
            {
                verticalPos = jumpHeight;
                IsJumping = true;
                playerAnims.ShowJumpAnim();
                if (coroutineSlide != null)
                {
                    StopCoroutine(coroutineSlide);
                    IsSliding = false;
                    ModifyColliderSlide(false);
                }
            }

            if (directionInput == DirectionInput.Slide)
            {
                if (IsSliding)
                {
                    return;
                }

                if (coroutineSlide != null)
                {
                    StopCoroutine(coroutineSlide);
                }
                SlideCharacter();
            }
        }
        else
        {
            if (directionInput == DirectionInput.Slide)
            {
                verticalPos -= jumpHeight;
                SlideCharacter();
            }
        }
        

        verticalPos -= gravity * Time.deltaTime;
    }

    private void ModifyColliderSlide(bool modify)
    {
        if (modify)
        {
            characterController.radius = 0.55f;
            characterController.height = 1.99f;
            characterController.center = new Vector3(0f, -1.79f, 0f);
        }
        else
        {
            characterController.radius = controllerRadius;
            characterController.height = controllerHeight;
            characterController.center = new Vector3(0f, controllerPosY, 0f);
        }
    }

    private void SlideCharacter()
    {
        coroutineSlide = StartCoroutine(SlideCharacterCO());
    }

    private IEnumerator SlideCharacterCO()
    {
        IsSliding = true;
        playerAnims.ShowCrouchAnim();
        ModifyColliderSlide(true);
        yield return new WaitForSeconds(2f);
        IsSliding = false;
        ModifyColliderSlide(false);
    }

    public void InputDetection()
    {
        directionInput = DirectionInput.Null;
        if (Input.GetKeyDown(KeyCode.W))
        {
            directionInput = DirectionInput.Jump;
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionInput = DirectionInput.Slide;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Obstacle"))
        {
            if (GameManager.Instance.CurrentState == GameStates.GameOver)
            {
                return;
            }
            playerAnims.ShowIdleAnim();
            GameManager.Instance.ChangeState(GameStates.GameOver);
        }
    }
}
