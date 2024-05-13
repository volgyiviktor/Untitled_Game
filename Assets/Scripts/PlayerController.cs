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

    public int jumpRemaining = 0;
    public float walkSpeed = 5F;
    public float runSpeed = 10F;
    public float airSpeed = 10F;
    private float jumpImpulse=10F;
    private float variableJump = 0.45F;
    private int facing = 1;
    Vector2 moveInput;
    TouchingDirections touchingDirections;

    /*public float CurrentMoveSpeed
    {
        get
        {
            if(touchingDirections.IsGrounded)
            {
                jumpRemaining = 1;
                if (IsMoving && !touchingDirections.IsOnWall)
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
                    return walkSpeed;
                }
            }
            else
            {
                return airSpeed;
            }
        }
    }*/

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
            facing*=-1;
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
        //rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        animator.SetFloat("YVelocity", rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
        if(isRunning)
        {
            rb.velocity = new Vector2(moveInput.x * 5, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput.x * 10, rb.velocity.y);
        }
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
        if (context.started && touchingDirections.IsGrounded && !touchingDirections.IsOnWall)
        {
            jumpRemaining=1;
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
            AudioManager.instance.Play("Jump");
        }
        else if (context.started && jumpRemaining>0 && !touchingDirections.IsOnWall)
        {
            jumpRemaining--;
            animator.SetTrigger("Jump");
            rb.velocity=new Vector2(rb.velocity.x, jumpImpulse);
            AudioManager.instance.Play("Jump");
        }
        else if(touchingDirections.IsOnWall && !touchingDirections.IsGrounded && moveInput.x==0)
        {
            jumpRemaining = 1;
            Vector2 forceToAdd = new Vector2(2.5f*-facing,5);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        else if(context.canceled && rb.velocity.y>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*variableJump);
        }
    }
}
