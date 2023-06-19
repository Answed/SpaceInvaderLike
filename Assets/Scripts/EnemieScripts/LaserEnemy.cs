using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : EnemyController
{
    private bool isFiring;

    private void Awake()
    {
        nextAttack = enemyStats.TimeBtwShots * 5 + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAttack <= Time.time && !isFiring)
        {
            nextAttack += enemyStats.TimeBtwShots * 5 + Time.time;
            StartCoroutine(Attack());
        }

        if (!isFiring)
            transform.Translate(Vector2.down * Time.deltaTime * enemyStats.Speed);

    }

    IEnumerator Attack()
    {
        isFiring = true;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemyStats.BulletPrefab, transform.position, enemyStats.BulletPrefab.transform.rotation);
            yield return new WaitForSeconds(enemyStats.TimeBtwShots);
        }
        isFiring = false;
    }
}
