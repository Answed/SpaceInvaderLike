using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private InputAction playerMovement;
    [SerializeField]
    private InputAction playerAttack;


    private Rigidbody2D rb2D;

    private Vector2 moveDirection;

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
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb2D.AddForce(moveDirection * speed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fired");
    }
}
