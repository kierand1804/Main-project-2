using UnityEngine;

/// <summary>
/// This script applies force in the raw direction of input.
/// This approach can be useful for a range of 2D games, and is easily adapted to suit others.
/// </summary>
public class FlyingMovementWASD : MonoBehaviour
{
    public float power = 5;
    Rigidbody2D body;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        body.AddForce(power * input);
    }
}
