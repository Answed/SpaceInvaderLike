using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUprade : MonoBehaviour, IInteractable
{
    [SerializeField]private float FireRateMultiplikator;
    public void OnPlayerCollision(PlayerController player)
    {
        StartCoroutine(FireRateUpgrade(player));
        gameObject.GetComponent<SpriteRenderer>().enabled = false;    
    }

    IEnumerator FireRateUpgrade(PlayerController player)
    {
        Debug.Log("Hello");
        player.timeBtwAttack /= FireRateMultiplikator;
        player.UpdatePlayerStatsText();
        yield return new WaitForSeconds(player.upgradeTime);
        Debug.Log("Hello");
        player.timeBtwAttack *= FireRateMultiplikator;
        player.UpdatePlayerStatsText();
        Destroy(gameObject);
    }
}
