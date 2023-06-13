using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : EnemyController
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * enemyStats.Speed * Time.deltaTime);

        if (nextAttack <= Time.time)
        {
            nextAttack = Time.time + enemyStats.TimeBtwShots;
            StartCoroutine(BurstAttack());
        }
        if (currentHealth == 0)
            Death();
    }

    IEnumerator BurstAttack()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyStats.BulletPrefab, transform.position, enemyStats.BulletPrefab.transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
