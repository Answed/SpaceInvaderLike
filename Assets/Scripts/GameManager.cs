using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int wave;

    [SerializeField] private float timeBtwWave;

    private WaveSpawner waveSpawner;

    private float nextWave;
    public bool nextWaveSpawned;

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesLeft.Length == 0 && !nextWaveSpawned)
        {
            nextWaveSpawned = true;
            StartCoroutine(SpawnWaveAfterTime());
        }
    }

    IEnumerator SpawnWaveAfterTime()
    {
        yield return new WaitForSeconds(timeBtwWave);
        wave++;
        waveSpawner.SpawnWave(wave);
    }
}
