using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : EnemyController
{
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
}
