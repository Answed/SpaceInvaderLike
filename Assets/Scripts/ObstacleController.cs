using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MoveObjects
{
    [SerializeField] private GameObject health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            DropHealth();
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void DropHealth()
    {
        var dropchance = Random.Range(0f, 1f);

        if (dropchance < 0.3f)
            Instantiate(health, transform.position, Quaternion.identity);
    }
}
