using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] obstacles;
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

        }
    }

    private void SpawnObject()
    {

    }

}
