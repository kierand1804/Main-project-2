using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementBasic : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D fellabody;
    Vector2 movement;



    // Start is called before the first frame update
    void Start()
    {
        fellabody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
          movement = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
          movement = Vector2.down * speed; 
          Camera.main.transform.right= movement;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = Camera.main.transform.right*speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement = Camera.main.transform.right * -speed;
        }
      fellabody.AddForce(movement);
        //fellabody.velocity= movement;
        
    }
}
