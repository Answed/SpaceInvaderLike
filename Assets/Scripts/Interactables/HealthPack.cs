using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour, IInteractable
{
    [SerializeField] private int amountOfHealth;
    public void OnPlayerCollision(PlayerController player)
    {
        player.PlayerHeal(amountOfHealth);
        Destroy(gameObject);
    }
}
