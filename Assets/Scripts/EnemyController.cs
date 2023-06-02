using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int scoreValue;
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth;
    [SerializeField] private float timeBtwShots;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject hitParticles;

    private int currentHealth;
    private float nextAttack;

    private GameManager gameManager;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (nextAttack <= Time.time)
        {
            nextAttack = Time.time + timeBtwShots;
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }

        if(currentHealth == 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameManager.UpDateScore(player.bulletDm);
            Destroy(collision.gameObject);
            currentHealth -= player.bulletDm;
            Instantiate(hitParticles, transform.position, Quaternion.identity); 
        }
    }
}
