using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D mRigidbody;
    private BoxCollider2D mCollider;

    public bool CanMoveHorizontally = true;
    public bool CanMoveVertically = false;

    public float MoveAcceleration = 6f;
    public float MaxMoveSpeed = 6f;

    public bool AffectedByGravity = true;
    public bool CanJump = true;

    [Range(0f, 10f)]
    public float JumpForce = 8f;

    Vector2 PlayerSize;
    public float GroundedBoxThickness = 0.1f;
    Vector2 GroundedBoxSize;
    public LayerMask GroundedLayer;

    private float HorizontalInput;
    private float VerticalInput;

    private float HorizontalVelocity;
    private float VerticalVelocity;

    private bool IsGrounded = false;
    private bool IsJumping = false;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (AffectedByGravity)
        {
            mRigidbody.gravityScale = 1f;
        }
        else
        {
            mRigidbody.gravityScale = 0f;
        }

        PlayerSize = mCollider.size;
        GroundedBoxSize = new Vector2(PlayerSize.x, GroundedBoxThickness);
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        if (CanJump && Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsJumping = true;
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here
    void FixedUpdate()
    {
        if (CanMoveHorizontally)
        {
            HorizontalVelocity = HorizontalInput * MoveAcceleration;
        } else
        {
            HorizontalVelocity = mRigidbody.velocity.x;
        }

        if (CanMoveVertically)
        {
            VerticalVelocity = VerticalInput * MoveAcceleration;
        } else
        {
            VerticalVelocity = mRigidbody.velocity.y;
        }

        mRigidbody.velocity = new Vector2(
            HorizontalVelocity,
            VerticalVelocity
        );

        if (IsJumping)
        {
            Jump();
        } else
        {
            Vector2 GroundedBoxCenter = (Vector2)transform.position + Vector2.down * (PlayerSize.y - GroundedBoxThickness) * 0.5f;
            IsGrounded = Physics2D.OverlapBox(GroundedBoxCenter, GroundedBoxSize, 0f, GroundedLayer) != null;
        }
        
    }

    void Jump()
    {
        mRigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        IsJumping = false;
        IsGrounded = false;
    }

}
