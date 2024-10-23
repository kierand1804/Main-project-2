 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obsticlePrefabs;
    public float obsticleSpawnTime = 2f;
    public float obsticleSpeed = 1f;

    private float timeUntilObsticleSpawn;

    private void Update()
    {
        SpawnLoop();
    }
    private void SpawnLoop()
    {
        timeUntilObsticleSpawn += Time.deltaTime;
        
        if(timeUntilObsticleSpawn >= obsticleSpawnTime)
        {
            Spawn();
            timeUntilObsticleSpawn = 0;
        }
    }



    private void Spawn()
    {
        GameObject obsticleToSpawn = obsticlePrefabs[Random.Range(0, obsticlePrefabs.Length)];
        GameObject spawnedObsticle = Instantiate(obsticleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obsticleRB = spawnedObsticle.GetComponent<Rigidbody2D>();
        obsticleRB.velocity = Vector2.left * obsticleSpeed;
    }
}
