using UnityEngine;

public class DynamicGravity : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(1, 10)]
    public float fallMultiplier = 5f;

    [Range(1, 10)]
    public float lowMultiplier = 5f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        } else
        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowMultiplier;
        } else
        {
            rb.gravityScale = 2f;
        }
    }
}
