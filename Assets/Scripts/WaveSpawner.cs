using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject obstacles;
    [SerializeField] private int spawnHeight;
    [SerializeField] private Vector2 spawnWidth; //I use vector 2 here 
    [SerializeField] private AnimationCurve enemySpawnCurve;
    [SerializeField] private AnimationCurve obstacleSpawnCurve;


    public void SpawnWave(int wave)
    {
        int enemiesToSpawn = (int)enemySpawnCurve.Evaluate(wave);
        int obstaclesToSpawn = (int)obstacleSpawnCurve.Evaluate(wave);

        for (int i = enemiesToSpawn + obstaclesToSpawn; i > 0; i--)
        {
            var spawnEnemie = Random.Range(0, 1);

            if (spawnEnemie <= 0.5f && enemiesToSpawn > 0)
            {
                enemiesToSpawn--;
                SpawnObject(0);
            }
            else if (obstaclesToSpawn > 0)
            {
                obstaclesToSpawn--;
                SpawnObject(1);
            }
            else if(obstaclesToSpawn == 0 && enemiesToSpawn > 0)
            {
                enemiesToSpawn--;
                SpawnObject(0);
            }
        }
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

}
