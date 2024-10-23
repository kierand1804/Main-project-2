using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Idle,

    Wandering,

    Follow,

    Die,
     
    Attack
};

public enum EnemyType
{
    Melee,
    
    Ranged
};

public class EnemyController : MonoBehaviour
{
    GameObject player;
    public EnemyState currentState = EnemyState.Idle;
    public EnemyType enemyType;

    public float range;
    public float speed;

    private bool chooseDir = false;
    private bool dead = false;
    private Vector3 randomDir;
    public float attackingRange = .5f;
    public int health = 3;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private bool coolDownAttack = false;
    public float coolDown;
    Rigidbody2D rb;

    AudioManager audioManager;
    public bool notInRoom = false;
    
    public GameObject projPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitForEnemiesLoading());
        BuffEnemyStats(GameController.floor);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //EnemyController[] allEnemies = FindObjectsOfType<EnemyController>();
        //GameController.instance.BuffEnemies(allEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (EnemyState.Idle):
                //Idle();
            break;

            case (EnemyState.Wandering):
                Wander();   
            break;
                
            case (EnemyState.Follow):
                Follow();
            break;

            case (EnemyState.Die):
                
            break;
                
            case (EnemyState.Attack):
                Attack();
            break;
        }
        if(!notInRoom)
        {
            if (IsPlayerInRange(range) && currentState != EnemyState.Die)
            {
                currentState = EnemyState.Follow;
            }
            else if (!IsPlayerInRange(range) && currentState != EnemyState.Die)
            {
                currentState = EnemyState.Wandering;
            }
            if (Vector3.Distance(transform.position, player.transform.position) <= attackingRange)
            {
                currentState = EnemyState.Attack;
            }
        }
        else
        {
            currentState = EnemyState.Idle;
        }
        if(transform.position.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        if(transform.position.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    public void BuffEnemyStats(float floorNumber)
    {
        health = Mathf.RoundToInt(floorNumber * health);
    }
    public IEnumerator WaitForEnemiesLoading()
    {
        yield return new WaitForSeconds(2f);
        //BuffEnemies(EnemyController[]);
    }
    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        //Quaternion nextRotation = Quaternion.Euler(randomDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }
    void Wander()
    {
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }
        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            currentState = EnemyState.Follow;
        }
    }
    
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Death()
    {
        
        
    }

    private void Attack()
    {
        if (!coolDownAttack)
        {
            switch(enemyType) 
            {
                case (EnemyType.Melee):
                    GameController.DamagePlayer(1);
                    audioManager.PlaySFX(audioManager.damage);
                    StartCoroutine(CoolDown());
                    break;
                case (EnemyType.Ranged):
                    GameObject projectile = Instantiate(projPrefab, transform.position, Quaternion.identity) as GameObject;
                    projectile.GetComponent<ProjectileController>().GetPlayer(player.transform);
                    projectile.AddComponent<Rigidbody2D>().gravityScale = 0;
                    projectile.GetComponent<ProjectileController>().isEnemyBullet = true;
                    audioManager.PlaySFX(audioManager.shooting);
                    StartCoroutine(CoolDown());
                    break;
                default:
                    break;
            }
        }

    }

    private IEnumerator CoolDown() 
    { 
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }
    public void TakeDamage(int damageDealt)
    {
        health -= damageDealt;
        Debug.Log("health: " + health); 
        if (health <= 0)
        {
            RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(gameObject);
        }
    }
}
