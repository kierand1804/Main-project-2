using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGravity2 : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //float X = Input.GetAxis("GravityL/R");
        //float Y = Input.GetAxis("GravityUP/Down");
        //Physics2D.gravity = new Vector2(X, Y).normalized * 8f;



        if (Input.GetKey(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0, 5f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0, -5f);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            Physics2D.gravity = new Vector2(5f, 0);
        }
        else if( Input.GetKey(KeyCode.A)) 
        {
            Physics2D.gravity = new Vector2(-5f, 0);
        }
        

        
    }
}
