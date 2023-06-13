using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour, IInteractable
{
    public void OnPlayerCollision(PlayerController player)
    {
        StartCoroutine(BulletUpgrade(player));
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public IEnumerator BulletUpgrade(PlayerController player)
    {
        player.amountOfBullets++;
        yield return new WaitForSeconds(player.upgradeTime);
        player.amountOfBullets--;
        Destroy(gameObject);
    }
}
