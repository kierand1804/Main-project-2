using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifeTime;
    public bool isEnemyBullet = false;
    public EnemyController enemyController;
    public GameObject [] enemy;
    private Vector2 lastPos;
    private Vector2 currentPos;
    private Vector2 playerPos;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
        if (!isEnemyBullet)
        {
            transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //enemy = GetComponents<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyBullet)
        {
            currentPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f *Time.deltaTime);
            if (currentPos == lastPos)
            {
                Destroy(gameObject);
            }
            lastPos = currentPos;
        }
        
    }

    public void GetPlayer(Transform player )
    {
        playerPos = player.position;
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Enemy" && !isEnemyBullet)
        {
            collision.gameObject.GetComponent<EnemyController>().Death();
            collision.GetComponent<EnemyController>().TakeDamage(GameController.Damage);
            Destroy(gameObject);
            
            audioManager.PlaySFX(audioManager.enemyDamage);
        }
        if (collision.tag == "Player" && isEnemyBullet)
        {
            GameController.DamagePlayer(1);
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.damage);
        }

    }
}
