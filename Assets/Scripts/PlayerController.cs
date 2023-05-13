using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : PlayerStats
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Slider healthBar; // For every 0.5 x scale move the healthbar 40 Units to the right 
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private InputAction playerAttack;

    private Rigidbody2D rb2D;

    private Vector2 moveDirection;
    private float nextAttack;
    private int currentHealth;

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
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
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
            UpdateHealth();
    }

    private void UpdateHealth()
    {
        currentHealth--;
        healthBar.value = currentHealth;
    }
}
