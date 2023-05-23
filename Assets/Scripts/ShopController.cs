using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MenuController
{
    [SerializeField] private int maxSpeedLevel;
    [SerializeField] private GameObject[] shopItems;

    private PlayerController player;

    private int speedLevel;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OpenShop()
    {
        EnableGameObjects(shopItems);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        DisableGameObjects(shopItems);
        player.UpdatePlayerStats();
        Time.timeScale = 1;
    }

    public void UpgradeHealth()
    {
        player.maxHealth += 2;
        player.UpdateHealthBar();
        CloseShop();
    }

    public void UpgradeSpeed()
    {
        if (speedLevel < maxSpeedLevel)
        {
            speedLevel++;
            player.speed++;
        }
        else Debug.Log("MaxLevel");
        CloseShop();
    }

    public void UpgradeDamage()
    {
        player.bulletDm++;
        CloseShop();
    }
}
