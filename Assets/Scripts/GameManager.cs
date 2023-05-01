using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int wave;

    [SerializeField] private float timeBtwWave;
    [SerializeField] private TextMeshProUGUI scoreText;

    private WaveSpawner waveSpawner;

    private float nextWave;
    private int score;
    public bool nextWaveSpawned;

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        scoreText.text = "Score: 0";
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
    
    public void UpDateScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnWaveAfterTime()
    {
        yield return new WaitForSeconds(timeBtwWave);
        wave++;
        waveSpawner.SpawnWave(wave);
    }
}
