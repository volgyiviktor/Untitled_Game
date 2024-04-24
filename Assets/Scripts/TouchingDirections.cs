using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;

    public float groundDistance = 0.05f;
    public float wallDistance = 0.02f;

    CapsuleCollider2D touchingCol;

    Animator animator;

    RaycastHit2D[] groundHits=new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];

    [SerializeField]
    private bool isGrounded;

    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
        private set
        {
            isGrounded = value;
            animator.SetBool("IsGrounded", value);
        }
    }

    [SerializeField]
    private bool isWallSliding;

    public bool IsWallSliding
    {
        get
        {
            return isWallSliding;
        }
        private set
        {
            isWallSliding = value;
            animator.SetBool("IsWallSliding", value);
        }
    }

    private Vector2 wallCheckDirections => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsWallSliding = touchingCol.Cast(wallCheckDirections, castFilter, wallHits, wallDistance) > 0;
    }
}
