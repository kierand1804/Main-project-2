using UnityEngine;

/// <summary>
/// This script allows an object to "dash" in a specific direction when Space is pressed.
/// The length and slowdown of the dash are dependent on the linear drag settings of the _rigidbody2D
/// </summary>
public class FlyingMovementDash : MonoBehaviour
{
    public float power = 5;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.sqrMagnitude > 0.5f)
        {
            transform.right = input;
        }
        if (Input.GetButtonDown("Jump"))
        {
            body.velocity = power * input.normalized;
        }
    }
}
