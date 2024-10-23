using UnityEngine;

/// <summary>
/// This script allows an object to handle similar to a tradition Asteroids game.
/// Movement is directed down the sprite's right vector, which is the expected facing direction for 2D objects.
/// </summary>
public class FlyingMovementRotating : MonoBehaviour
{
    public float power = 5;
    public float turnSpeed = 180;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        body.angularVelocity = turnSpeed * -input.x;
        body.AddForce(power * input.y * transform.right);
    }
}
