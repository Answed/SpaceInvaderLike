using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    public int armor;
    public float speed;
    public int bulletDm;
    public float timeBtwAttack;
    public float upgradeTime;
    public int amountOfBullets;
    [SerializeField] private Transform[] bulletPositions;
    [SerializeField] private AnimationCurve DamageReduction; // Based on the current armor value
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject hitParticles;
    [SerializeField] private Slider healthBar; // For every 0.5 x scale move the healthbar 40 Units to the right 
    [SerializeField] private TextMeshProUGUI healthStatsText;
    [SerializeField] private TextMeshProUGUI speedStatsText;
    [SerializeField] private TextMeshProUGUI damageStatsText;
    [SerializeField] private TextMeshProUGUI fireRateStatsText;
    [SerializeField] private TextMeshProUGUI upgradeTimeText;
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private InputAction playerAttack;

    private Rigidbody2D rb2D;

    private Vector2 moveDirection;
    private float nextAttack;
    private float currentHealth;

    private GameManager gameManager;
    private AudioManager audioManager;

    private void OnEnable()
    {
        playerMovement.Enable();
        playerAttack.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
        playerAttack.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        ApplyPlayerUpgrades();
        currentHealth = maxHealth;
        healthBar.maxValue = currentHealth;
        healthBar.value = currentHealth;
        amountOfBullets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameManager.gameIsActive)
        {
            case true:
                GetComponent<Collider2D>().enabled = true;
                moveDirection = playerMovement.ReadValue<Vector2>();

                if(nextAttack < Time.time && playerAttack.ReadValue<float>() == 1)
                {
                    nextAttack = Time.time + timeBtwAttack;
                    Shoot();
                }
                break;
            case false:
                moveDirection = new Vector2(0, 0);
                GetComponent<Collider2D>().enabled = false;
                break;
        }
        
        if(currentHealth <= 0)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb2D.AddForce(moveDirection * speed);
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EBullet"))
            collision.GetComponent<Bullet>().OnPlayerHit(this);

        if(collision.TryGetComponent(out IInteractable objectColided))
            objectColided.OnPlayerCollision(this);

        if (collision.CompareTag("Obstacle"))
            UpdateHealth(4);
    }
    private void Shoot()
    {
        audioManager.Play("LaserShot");
        switch(amountOfBullets)
        {
            case 0:
                Instantiate(bulletPrefab, bulletPositions[0].position, transform.rotation);
                break;
            case 1:
                Instantiate(bulletPrefab, bulletPositions[1].position, transform.rotation);
                Instantiate(bulletPrefab, bulletPositions[2].position, transform.rotation);
                break;
            case 2:
                Instantiate(bulletPrefab, bulletPositions[0].position, transform.rotation);
                Instantiate(bulletPrefab, bulletPositions[1].position, transform.rotation);
                Instantiate(bulletPrefab, bulletPositions[2].position, transform.rotation);
                break;
        }
    }

    #region Stats&Visuals
    public void PlayerHit(int Damage)
    {
        UpdateHealth(Damage);
        Instantiate(hitParticles, transform.position, Quaternion.identity);
    }

    public void PlayerHeal(int amount)
    {
        if (currentHealth == maxHealth - 1)
            UpdateHealth(-1);
        else
            UpdateHealth(-amount);
    }
    private void UpdateHealth(int damage)
    {
        var actualDamage = damage - (damage * DamageReduction.Evaluate(armor));
        currentHealth -= actualDamage;
        healthBar.value = currentHealth;
    }

    private void ApplyPlayerUpgrades()
    {
        PlayerUpgrades playerUpgrades = SaveLoadSystem.SaveSystemManager.LoadPlayerUpgrades();
        maxHealth += playerUpgrades.HealthUpgrade;
        armor += playerUpgrades.ArmorUpgrades;
        speed += playerUpgrades.SpeedUpgrade;
        bulletDm += playerUpgrades.DamageUpgrade;
        UpdatePlayerStatsText();
        for (int i = 4; i < maxHealth; i++)
        {
            UpdateHealthBar();
        }
    }
    public void UpdatePlayerStatsText()
    {
        healthStatsText.text = "Health: " + maxHealth;
        speedStatsText.text = "Speed: " + speed;
        damageStatsText.text = "Damage: " + bulletDm;
        fireRateStatsText.text = "Fire Rate: " + 0.6f / (timeBtwAttack * 0.6f);
        upgradeTimeText.text = "Duration: " + upgradeTime;
    }
    public void UpdateHealthBar()
    {
        healthBar.maxValue = maxHealth;
        healthBar.transform.position = healthBar.transform.position + new Vector3(40, 0 , 0);
        healthBar.transform.localScale = healthBar.transform.localScale + new Vector3(0.5f, 0, 0);
    }
    #endregion
}
