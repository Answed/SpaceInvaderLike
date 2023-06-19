using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : EnemyController
{
    [SerializeField] private float timeForBuildUp;
    [SerializeField] private int laserDamage;
    [SerializeField ]private float timeBtwLaserDamage;

    private bool isFiring;
    private bool laserIsActive;
    private float nextLaserDamage;

    private void Awake()
    {
        nextAttack = enemyStats.TimeBtwShots * 5 + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAttack <= Time.time && !isFiring)
        {
            nextAttack = enemyStats.TimeBtwShots * 5 + Time.time;
            StartCoroutine(Attack());
        }

        if (!isFiring)
            transform.Translate(Vector2.down * Time.deltaTime * enemyStats.Speed);
        if(laserIsActive && nextLaserDamage <= Time.time)
        {
            nextLaserDamage = Time.time + timeBtwLaserDamage;
            LaserBeam();
        }
    }

    private void LaserBeam()
    {
        Collider2D player = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 26 - Mathf.Abs(transform.position.y)), 0f);
        if (player != null)
            player.gameObject.GetComponent<PlayerController>().PlayerHit(laserDamage);
    }

    IEnumerator Attack()
    {
        isFiring = true;
        //start animation
        yield return new WaitForSeconds(timeForBuildUp); //Laser animation needs some time to build up
        laserIsActive = true;
        yield return new WaitForSeconds(5);
        laserIsActive = false;
        isFiring = false;
    }
}
