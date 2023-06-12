using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject obstacles;
    [SerializeField] private int spawnHeight;
    [SerializeField] private float timeBtwSpawns;
    [SerializeField] private Vector2 spawnWidth; //I use vector 2 here 

    private float nextSpawn;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();  
    }

    public void SpawnWave(int wave)
    {
        int enemiesToSpawn = wave * 2;
        StartCoroutine(SpawnEnemies(enemiesToSpawn));
    }

    private void SpawnObject(GameObject kindOfObject)
    {
        float xSpawnValue = Random.Range(spawnWidth.x, spawnWidth.y);
        Instantiate(kindOfObject, new Vector2(xSpawnValue, spawnHeight), kindOfObject.transform.rotation);
    }

    IEnumerator SpawnEnemies(int enemiesToSpawn)
    {
        while(enemiesToSpawn > 0 )
        {
            var spawnEnemie = Random.Range(0f, 1f);

            yield return new WaitForSeconds(timeBtwSpawns);

            if (spawnEnemie < 0.4f && enemiesToSpawn > 0)
            {
                enemiesToSpawn--;
                SpawnObject(enemies);
            }
        }
        gameManager.nextWaveSpawned = false;
    }

    public void SpawnObstacles()
    {
        if(nextSpawn < Time.time)
        {
            nextSpawn = Time.time + timeBtwSpawns;
            SpawnObject(obstacles);
        }
    }
}
