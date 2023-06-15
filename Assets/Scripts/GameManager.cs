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
    [SerializeField] private TextMeshProUGUI pauseMenuTitle;
    [SerializeField] private GameObject[] pauseMenuObjects;
    [SerializeField] private GameObject[] settingsMenuObjects;
    [SerializeField] private GameObject[] gameOverScreenObjects;
    [SerializeField] private InputAction startGame;
    [SerializeField] private InputAction endGame;
    [SerializeField] private InputAction pauseGame;

    private WaveSpawner waveSpawner;
    private PerkSelectionControler perkSelectionControler;

    private float nextWave;
    private int score;
    public bool nextWaveSpawned;
    public bool gameIsActive;
    public bool spawnObstacles;
    

    private void OnEnable()
    {
        startGame.Enable();
        startGame.performed += StartGame;
        pauseGame.Enable();
        pauseGame.performed += PauseGame;
    }

    private void OnDisable()
    {
        pauseGame.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        perkSelectionControler = GetComponent<PerkSelectionControler>();
        scoreText.text = "Score: 0";
        gameIsActive = false;
        startGameText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsActive)
            WaveManager();
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
            spawnObstacles = false;
            StartCoroutine(SpawnWaveAfterTime());
        }
        if (spawnObstacles)
            waveSpawner.SpawnObstacles();
    }
    
    private void StartGame(InputAction.CallbackContext context)
    {
        startGameText.SetActive (false);
        gameIsActive = true;
        startGame.Disable();
    }

    public void GameOver()
    {
        endGame.Enable();
        endGame.performed += ReloadScene;
        gameIsActive = false;
        MenuController.EnableGameObjects(gameOverScreenObjects);
        SaveLoadSystem.SaveSystemManager.SaveScore(score + SaveLoadSystem.SaveSystemManager.LoadScore());
    }

    private void ReloadScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("GameScene");
        endGame.Disable();
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        if(gameIsActive)
        {
            gameIsActive = false;
            MenuController.EnableGameObjects(pauseMenuObjects);
            blackScreen.SetActive(true);
            pauseMenuTitle.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else Resume();
    }

    public void Resume()
    {
        gameIsActive = true;
        MenuController.DisableGameObjects(pauseMenuObjects);
        blackScreen.SetActive(false);
        pauseMenuTitle.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Settings()
    {
        MenuController.SwitchWindow(pauseMenuObjects, settingsMenuObjects);
        pauseMenuTitle.text = "Settings";
    }
    // Goes back to the MainPauseMenu
    public void Back()
    {
        MenuController.SwitchWindow(settingsMenuObjects, pauseMenuObjects);
        pauseMenuTitle.text = "Paused";
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // Gives the player a moment to breath before the next wave starts
    IEnumerator SpawnWaveAfterTime()
    {
        yield return new WaitForSeconds(timeBtwWave);
        wave++;
        waveSpawner.SpawnWave(wave);
        spawnObstacles = true;
    }
}
