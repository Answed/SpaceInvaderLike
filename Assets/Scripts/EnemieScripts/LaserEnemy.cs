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
        nextAttack = enemyStats.TimeBtwShots + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAttack <= Time.time && !isFiring)
        {
            nextAttack = enemyStats.TimeBtwShots + Time.time;
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
        float distanceToMapBorder = Vector2.Distance(transform.position, new Vector2(transform.position.x, -11f));
        Collider2D player = Physics2D.OverlapBox(new Vector2(transform.position.x, -(11-distanceToMapBorder / 2.15f)), new Vector2(1, distanceToMapBorder), 0f);
        if (player != null)
            Debug.Log(player);
    }

    IEnumerator Attack()
    {
        isFiring = true;
        //start animation
        yield return new WaitForSeconds(timeForBuildUp); //Laser animation needs some time to build up
        laserIsActive = true;
        yield return new WaitForSeconds(3);
        laserIsActive = false;
        isFiring = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        
        float distanceToMapBorder = Vector2.Distance(transform.position, new Vector2(transform.position.x, -11f));
        Gizmos.DrawCube(new Vector3(transform.position.x, -(11-distanceToMapBorder/2.15f), 0), new Vector3(1, distanceToMapBorder, 1));
    }
}
