using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : EnemyController
{
    private bool moveLeft;
    private void Awake()
    {
        float distancefromLeft =transform.position.x;
        Debug.Log(distancefromLeft);
        if (distancefromLeft < 0)
            moveLeft = false;
        if (distancefromLeft > 0 )
            moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * enemyStats.Speed * Time.deltaTime);

        MoveFromSideToSide();

        if (nextAttack <= Time.time)
        {
            nextAttack = Time.time + enemyStats.TimeBtwShots;
            StartCoroutine(BurstAttack());
        }

        if (currentHealth == 0)
            Death();
    }

    private void MoveFromSideToSide()
    {
        if(moveLeft && transform.position.x >= -12)
            transform.Translate(Vector2.left * enemyStats.Speed * 12 * Time.deltaTime);
        else transform.Translate(Vector2.right * enemyStats.Speed * 12 * Time.deltaTime);
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (transform.position.x <= -11.5f)
            moveLeft = false;
        else if(transform.position.x >= 11.5f)
            moveLeft = true;
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
