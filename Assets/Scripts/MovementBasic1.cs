using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementBasic1 : MonoBehaviour
{
    public float speed;
    Rigidbody2D fellabody;
    Vector2 movement;

    public GameObject projPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;
    Animator animator;
    public static int collectedAmount = 0;
    SpriteRenderer spriteRenderer;
    public GameObject pauseMenu;
    public bool gamePaused = false;
    public bool pauseMenuActive = false;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        fellabody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        fireDelay = GameController.FireRate;
        speed = GameController.MoveSpeed;

        movement = Vector2.zero;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    movement = Vector2.up * speed;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    movement = Vector2.down * speed;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    movement = Vector2.right * speed;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    movement = Vector2.left * speed;
        //}

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");

        if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, shootVert);
            audioManager.PlaySFX(audioManager.shooting);
            lastFire = Time.time;
        }


        fellabody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        //fellabody.velocity= movement;
    

        animator.SetFloat("Speed", Mathf.Abs(fellabody.velocity.x));

        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }



        if (gamePaused == false & Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
            
        }
        else if (gamePaused == true & Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
            
        }
    }
    

    void Shoot(float x, float y)
    {
        GameObject projectile = Instantiate(projPrefab, transform.position, transform.rotation) as GameObject;
        projectile.AddComponent<Rigidbody2D>().gravityScale = 0;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(
              (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
              (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
              0
            );
    }
}
