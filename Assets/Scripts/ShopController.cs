using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MenuController
{
    [SerializeField] private GameObject[] shopItems;

    private PlayerController player;

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
        Time.timeScale = 1;
    }

    public void UpgradeHealth()
    {
        player.maxHealth += 2;
        CloseShop();
    }

    public void UpgradeSpeed()
    {
        player.speed++;
        CloseShop();
    }

    public void UpgradeDamage()
    {
        player.bulletDm++;
        CloseShop();
    }
}
