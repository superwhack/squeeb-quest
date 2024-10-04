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

    private float xVelocity;

    private KeyControl keyControl = new KeyControl();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xVelocity * speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        xVelocity = context.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext context)
    {

    }
}
