using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private int bulletDm;
    [SerializeField]
    private bool destructable;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") && destructable)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void OnPlayerHit(PlayerController playerController)
    {
        playerController.PlayerHit(bulletDm);
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
