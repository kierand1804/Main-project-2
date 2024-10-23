using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigidbody2;
    private void Start()
    {
       rigidbody2 = GetComponent<Rigidbody2D>();
        rigidbody2.velocity = Vector2.left * speed;
    }
    void Update()
    {
        
    }
}
