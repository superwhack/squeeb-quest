using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce;

    private float xDirection;

    [SerializeField]
    private int maxJumps = 1;

    [SerializeField]
    private int jumps;

    [SerializeField]
    private float jumpDelay = 0.25f;

    private float jumpTimer = 0f;
    public bool jumped = false;

    [SerializeField]
    private float maxVelocity;




    void Start()
    {
        jumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(xDirection * speed, rb.velocity.y, 0);

        if (jumped )
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer > jumpDelay)
            {
                jumped = false;
                jumpTimer = 0f;
            }
        }

        if (rb.velocity.y > maxVelocity)
        {
            Vector2 movementDirection = rb.velocity.normalized;
            float magnitudeDifference = rb.velocity.y - maxVelocity;

            rb.AddForce(movementDirection * magnitudeDifference * -1);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!jumped && jumps > 0)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                jumps--;
                jumped = true;
                jumpTimer = 0f;
            }
        }
    }

    public int Jumps
    {
        get { return jumps; }
        set { jumps = value; }
    }

    public int MaxJumps
    {
        get
        {
            return maxJumps;
        }
        set { maxJumps = value; }
    }
}
