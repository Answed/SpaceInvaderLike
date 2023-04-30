using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int wave;

    [SerializeField] private float timeBtwWave;

    private WaveSpawner waveSpawner;

    private float nextWave;

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesLeft.Length == 0 && nextWave <= Time.time)
        {
            wave++;
            nextWave = Time.time + timeBtwWave;
            waveSpawner.SpawnWave(wave);
        }
    }

}
