using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public EnemyScriptableObject enemyStats;

    protected int currentHealth;
    protected float nextAttack;

    protected GameManager gameManager;
    protected PlayerController player;
    protected AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(gameManager.gameIsActive)
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentHealth = enemyStats.MaxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            currentHealth -= player.bulletDm;
            Instantiate(enemyStats.HitParticles, transform.position, Quaternion.identity); 
        }
    }

    protected void Death()
    {
        var random = Random.Range(0f, 1f);

        if(random <= 0.3f  && enemyStats.PowerUpPrefab != null)
            Instantiate(enemyStats.PowerUpPrefab, transform.position, enemyStats.PowerUpPrefab.transform.rotation);

        gameManager.UpDateScore(enemyStats.ScoreValue);
        Destroy(gameObject);
    }
}
