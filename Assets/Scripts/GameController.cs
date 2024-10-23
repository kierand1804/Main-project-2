using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Xml.Serialization;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    //sets all my players stats (base stats)
    private static float health = 6;
    private static float maxHealth = 6;
    private static float moveSpeed = 3f;
    private static float fireRate = 0.5f;
    private static float bulletSize = .5f;
    private static int damage = 2;
    public static int floor = 1;

    //getter and setter variables for public use
    public static float Health { get => health; set => health = value; }
    public static float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }
    public static float BulletSize { get => bulletSize; set => bulletSize = value; }
    public static int Damage { get => damage; set => damage = value; }
    public static int Floor { get => floor; set => floor = value; }


    public List<string> collectedNames = new List<string>();
    public EnemyController enemy;
    public TMP_Text floorNum;
    public GameObject deathScreen;
    AudioManager audioManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        floorNum.text = ("Floor Number: " + floor);

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }
    private void Start()
    {
        
    }

    private IEnumerator FindDeathScreen()
    {
        yield return null;
      deathScreen = GameObject.FindGameObjectWithTag("DeathUI");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(damage);
        if (health < 0)
        {
            deathScreen.SetActive(true);
            audioManager.PlaySFX(audioManager.death);
        }
    }

    public static void DamagePlayer(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(MaxHealth, Health + healAmount);
    }

    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }
    public static void BulletSizeChange(float size)
    {
        bulletSize += size;
    }

    public static void DamageUp(int damageIncrease)
    {
        damage += damageIncrease;
    }

    public static void DamageEnemy(GameObject target)
    {
        var enemycontroller = target.GetComponent<EnemyController>();
        if (enemycontroller != null )
        {
            enemycontroller.TakeDamage(Damage);           
        }
    }
    private static void KillPlayer()
    {
        
       
        if (instance.deathScreen != null) 
        {
            
        }
        else
        {
            Debug.LogWarning("deathscreen gameobject not found");
        }
        if (health <= 0)
        {
            Time.timeScale = 0;

            //Instantiate(instance.audioManager.PlaySFX(audioManager.damage));
            Instantiate(instance.deathScreen);
            instance.deathScreen.SetActive(true);
           

        }
    }
    public void UpdateCollectedItems(CollectionController item)
    {
        collectedNames.Add(item.item.name);

        foreach (string i in collectedNames)
        {
            switch (i)
            {

            }
        }

    }
    public void IncreaseFloorNum()
    {
        floor++;
        floorNum.text = ("Floor: " +  floor.ToString());
        BuffEnemies();
    }
    public void BuffEnemies()
    {
        
        int initialFloor = GameController.floor;
        int floorDifference = GameController.floor - initialFloor;
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();

        foreach(EnemyController enemy in enemies)
        {
            enemy.BuffEnemyStats(floor);
        }
    }
    public void ResetPlayerStats()
    {
        health = 6;
        maxHealth = 6;
        moveSpeed = 3f;
        fireRate = 0.5f;
        bulletSize = .5f;
        damage = 2;
        floor = 1;
    }
}
