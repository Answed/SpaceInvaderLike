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
    [SerializeField] private AnimationCurve DamageReduction; // Based on the current armor value
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject hitParticles;
    [SerializeField] private Slider healthBar; // For every 0.5 x scale move the healthbar 40 Units to the right 
    [SerializeField] private TextMeshProUGUI healthStatsText;
    [SerializeField] private TextMeshProUGUI speedStatsText;
    [SerializeField] private TextMeshProUGUI damageStatsText;
    [SerializeField] private TextMeshProUGUI fireRateStatsText;
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private InputAction playerAttack;

    private Rigidbody2D rb2D;

    private Vector2 moveDirection;
    private float nextAttack;
    private float currentHealth;

    private GameManager gameManager;

    private void OnEnable()
    {
        playerMovement.Enable();
        playerAttack.Enable();
        playerAttack.performed += Fire;
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
        ApplyPlayerUpgrades();
        currentHealth = maxHealth;
        healthBar.value = currentHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameIsActive)
            moveDirection = playerMovement.ReadValue<Vector2>();
        if(currentHealth == 0)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb2D.AddForce(moveDirection * speed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if(nextAttack < Time.time && gameManager.gameIsActive)
        {
            nextAttack = Time.time + timeBtwAttack;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EBullet"))
        {
            UpdateHealth(1);
            Instantiate(hitParticles, transform.position, Quaternion.identity);
        }
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
        UpdateHealthBar();
    }

    public void UpdatePlayerStatsText()
    {
        healthStatsText.text = "Health: " + maxHealth;
        speedStatsText.text = "Speed: " + speed;
        damageStatsText.text = "Damage: " + bulletDm;
        fireRateStatsText.text = "Fire Rate: " + 0.6f / (timeBtwAttack * 0.6f);
    }



    public void UpdateHealthBar()
    {
        healthBar.maxValue = maxHealth;
        healthBar.transform.position = healthBar.transform.position + new Vector3(40, 0 , 0);
        healthBar.transform.localScale = healthBar.transform.localScale + new Vector3(0.5f, 0, 0);
    }
}
