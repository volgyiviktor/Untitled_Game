using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;

    CapsuleCollider2D touchingCol;

    Animator animator;

    public float groundDistance = 0.05f;

    RaycastHit2D[] groundHits=new RaycastHit2D[5];

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

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public float wallDistance = 0.02f;

    RaycastHit2D[] wallHits = new RaycastHit2D[5];

    [SerializeField]
    private bool isOnWall;

    public bool IsOnWall
    {
        get
        {
            return isOnWall;
        }
        private set
        {
            isOnWall = value;
            animator.SetBool("IsOnWall", value);
        }
    }

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
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
    }
}
