using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumo : MonoBehaviour
{
    public float jumpForce = 5;
    Rigidbody2D rb;
    Vector2 jumping;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //jumping = Vector2.up * jumpForce;
            //rb.AddForce (jumping);
            rb.AddForce(Physics2D.gravity.normalized * -jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;
        }
    }




}
//need a timer for the jump every 3 seconds