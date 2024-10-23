using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public Vector2 speed;
    float maxVelocity = 10;
    public GameObject pauseMenu;
    public bool gamePaused;
    public GameObject deathScreen;

    void FixedUpdate()
    {
        float currentYSpeed = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = speed;
        _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, maxVelocity);
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, currentYSpeed);

    }
    private void Update()
    {
        if (deathScreen.active == false & gamePaused == false & Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
        }
        else if (deathScreen.active == false & gamePaused == true & Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }

}
