using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int wave;

    [SerializeField] private float timeBtwWave;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startGameText;
    [SerializeField] private InputAction startGame;

    private WaveSpawner waveSpawner;

    private float nextWave;
    private int score;
    public bool nextWaveSpawned;
    public bool gameStarted;

    private void OnEnable()
    {
        startGame.Enable();
        startGame.performed += StartGame;
    }
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        scoreText.text = "Score: 0";
        gameStarted = false;
        startGameText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted)
        {
            WaveManager();
        }
    }
    
    public void UpDateScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = "Score: " + score;
    }

    //Checks if all enemies on screen have died and then spawns the next wave after some time.
    private void WaveManager()
    {
        GameObject[] enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesLeft.Length == 0 && !nextWaveSpawned)
        {
            nextWaveSpawned = true;
            StartCoroutine(SpawnWaveAfterTime());
        }
    }
    
    private void StartGame(InputAction.CallbackContext context)
    {
        startGameText.SetActive (false);
        gameStarted = true;
        Debug.Log("Game Started");
        startGame.Disable();
    }

    // Gives the player a moment to breath before the next wave starts
    IEnumerator SpawnWaveAfterTime()
    {
        yield return new WaitForSeconds(timeBtwWave);
        wave++;
        waveSpawner.SpawnWave(wave);
    }
}
