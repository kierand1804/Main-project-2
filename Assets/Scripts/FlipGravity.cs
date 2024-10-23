using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour
{
    // Start is called before the first frame update

    bool originFromFlip = true;
    // Update is called once per frame
    void Start()
    {
        originFromFlip = true; 
        Physics2D.gravity = new Vector2(0, -5f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flip();
        }
    }

    void Flip()
    {
        if (originFromFlip == true)
        {
            Physics2D.gravity = new Vector2(0, 12f);
            originFromFlip = false;
        }
        else if (originFromFlip == false)
        {
            Physics2D.gravity = new Vector2(0, -12f);
            originFromFlip = true;
        }
    }
}
