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
        StartCoroutine(SpawnDelay(enemiesToSpawn));
    }

    private void SpawnObject(int kindOfObject)
    {
        float xSpawnValue = Random.Range(spawnWidth.x, spawnWidth.y);
        switch (kindOfObject)
        {
            case 0:
                Instantiate(enemies, new Vector2(xSpawnValue, spawnHeight), enemies.transform.rotation);
                break;
            case 1:
                Instantiate(obstacles, new Vector2(xSpawnValue, spawnHeight), obstacles.transform.rotation); 
                break; 
        }
    }

    IEnumerator SpawnDelay(int enemiesToSpawn)
    {
        for (int i = enemiesToSpawn; i > 0; i--)
        {
            var spawnEnemie = Random.Range(0, 1);

            yield return new WaitForSeconds(timeBtwSpawns);

            if (spawnEnemie <= 0.5f && enemiesToSpawn > 0)
            {
                enemiesToSpawn--;
                SpawnObject(0);
            }
            else { SpawnObject(1); }
        }
        gameManager.nextWaveSpawned = false;
    }

}
