using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject obstacles;
    [SerializeField] private int spawnHeight;
    [SerializeField] private float timeBtwSpawns;
    [SerializeField] private Vector2 spawnWidth; //I use vector 2 here to give a span where they can spawn in between
    [SerializeField] private AnimationCurve spawnCurve;

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
        float xSpawnValue = Random.Range((int)spawnWidth.x, (int)spawnWidth.y);
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
                KindOfEnemieGetsSpawned();
            }
        }
        gameManager.nextWaveSpawned = false;
    }

    private void KindOfEnemieGetsSpawned()
    {
        var randomEnemie = Random.Range(0f, 1.5f);
        var enemieVariation = spawnCurve.Evaluate(gameManager.wave);
        if (randomEnemie > enemieVariation*3)
            SpawnObject(enemies[0]);
        else if (randomEnemie < enemieVariation * 3 && randomEnemie > enemieVariation*2)
            SpawnObject(enemies[1]);
        else if(randomEnemie < enemieVariation * 2 && randomEnemie > enemieVariation)
            SpawnObject(enemies[2]);
        else SpawnObject(enemies[3]);
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
