using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int wave;

    [SerializeField] private float timeBtwWave;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startGameText;
    [SerializeField] private GameObject blackScreen; // In Unity it is GameIsInActiveBG -> So i can toggle it indipendet from the other stuff
    [SerializeField] private GameObject[] pauseMenuObjects;
    [SerializeField] private GameObject[] settingsMenuObjects;
    [SerializeField] private GameObject[] gameOverScreenObjects;
    [SerializeField] private InputAction startGame;
    [SerializeField] private InputAction endGame;

    private WaveSpawner waveSpawner;
    private MenuController menuController;

    private float nextWave;
    private int score;
    public bool nextWaveSpawned;
    public bool gameIsActive;

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
        gameIsActive = false;
        startGameText.SetActive(true);
        menuController = new MenuController();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsActive)
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
        gameIsActive = true;
        Debug.Log("Game Started");
        startGame.Disable();
    }

    public void GameOver()
    {
        endGame.Enable();
        endGame.performed += ReloadScene;
        gameIsActive = false;
        menuController.EnableGameObjects(gameOverScreenObjects);
    }

    private void ReloadScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("GameScene");
        endGame.Disable();
    }

    // Gives the player a moment to breath before the next wave starts
    IEnumerator SpawnWaveAfterTime()
    {
        yield return new WaitForSeconds(timeBtwWave);
        wave++;
        waveSpawner.SpawnWave(wave);
    }
}
