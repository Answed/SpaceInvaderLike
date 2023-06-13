using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour, IInteractable
{
    [SerializeField] private float FireRateMultiplikator;
    public void OnPlayerCollision(PlayerController player)
    {
        StartCoroutine(FireRateUpgrade(player));
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator FireRateUpgrade(PlayerController player)
    {
        player.timeBtwAttack /= FireRateMultiplikator;
        player.UpdatePlayerStatsText();
        yield return new WaitForSeconds(player.upgradeTime);
        player.timeBtwAttack *= FireRateMultiplikator;
        player.UpdatePlayerStatsText();
        Destroy(gameObject);
    }
}
