using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    
    Animator animator;

    public float walkSpeed = 5F;
    public float runSpeed = 10F;
    public float airSpeed = 7F;
    private float jumpImpulse=10F;
    Vector2 moveInput;
    TouchingDirections touchingDirections;

    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving && !touchingDirections.IsOnWall)
            {
                if (touchingDirections.IsGrounded)
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
                    return airSpeed;
                }

            }
            else
            {
                return 0;
            }
        }
    }

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
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        touchingDirections= GetComponent<TouchingDirections>();
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
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
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
        if(context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger("Jump");
            rb.velocity=new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
