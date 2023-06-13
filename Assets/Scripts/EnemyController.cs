using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject enemyStats;

    private int currentHealth;
    private float nextAttack;

    private GameManager gameManager;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentHealth = enemyStats.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * enemyStats.Speed * Time.deltaTime);

        if (nextAttack <= Time.time)
        {
            nextAttack = Time.time + enemyStats.TimeBtwShots;
            Instantiate(enemyStats.BulletPrefab, transform.position, enemyStats.BulletPrefab.transform.rotation);
        }

        if (currentHealth == 0)
            Death();
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

    private void Death()
    {
        var random = Random.Range(0f, 1f);

        if(random <= 0.3f  && enemyStats.PowerUpPrefab != null)
        {
                Instantiate(enemyStats.PowerUpPrefab, transform.position, enemyStats.PowerUpPrefab.transform.rotation);
        }

        gameManager.UpDateScore(enemyStats.ScoreValue);
        Destroy(gameObject);
    }
}
