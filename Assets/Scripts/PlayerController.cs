using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    
    Animator animator;

    public float walkSpeed = 5F;
    public float runSpeed = 10F;
<<<<<<< Updated upstream
    private float jumpImpulse=10F;
=======
    public float airSpeed = 5F;
    public float runAirSpeed = 10F;
    private float jumpImpulse = 10F;
    private float jumpHeightMultiplier = 0.5F;
    private float wallHopForce=2000F;
    private float wallJumpForce=2000F;

    Vector2 wallHopDirection;
    Vector2 wallJumpDirection;

>>>>>>> Stashed changes
    Vector2 moveInput;
    TouchingDirections touchingDirections;

    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }
            else
            {
                if (WallJump)
                {
                    return walkSpeed;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    private bool WallJump = false;

    [SerializeField]
    private bool isMoving = false;
    public bool IsMoving
    {
        get
        {
            return isMoving;
        }
        private set
        {
            isMoving = value;
            animator.SetBool("IsMoving", value);
        }
    }

    [SerializeField]
    private bool isRunning = false;
    public bool IsRunning
    {
        get
        {
            return isRunning;
        }
        private set
        {
            isRunning = value;
            animator.SetBool("IsRunning", value);
        }
    }

    private bool isFacingRight = true;
    private int facingDirection = 1;

    public bool IsFacingRight
    {
        get
        {
            return isFacingRight;
        }
        private set
        {
            transform.localScale *= new Vector2(-1, 1);
            isFacingRight = value;
            facingDirection*=-1;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        touchingDirections= GetComponent<TouchingDirections>();
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!touchingDirections.IsWallSliding)
        {
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        }
        animator.SetFloat("YVelocity", rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x>0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x<0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            IsRunning = true;
        }
        else if(context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump (InputAction.CallbackContext context)
    {
<<<<<<< Updated upstream
        if(context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger("Jump");
            rb.velocity=new Vector2(rb.velocity.x, jumpImpulse);
            AudioManager.instance.Play("Jump");
=======
        if (context.started && touchingDirections.IsGrounded) //sima ugrás
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }

        else if (context.started && touchingDirections.IsWallSliding) //leugrás a fallról
        {
            WallJump = true;
            animator.SetTrigger("Jump");
            //Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * -facingDirection, wallHopForce * wallHopDirection.y);
            Vector2 forceToAdd = new Vector2(100 * -facingDirection, 5);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            WallJump = false;
        }

        if (context.canceled) //állítható magasságú ugrás
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*jumpHeightMultiplier);
>>>>>>> Stashed changes
        }
    }
}
