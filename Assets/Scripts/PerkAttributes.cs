using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IApplyAttribute
{
    void Apply(float value, PlayerController player);
}

public class MaxHealth : IApplyAttribute
{
    public void Apply(float value, PlayerController player)
    {
        player.maxHealth = (int)value;
        player.UpdateHealthBar();
        player.UpdatePlayerStatsText();
    }
}

public class Armor : IApplyAttribute
{
    public void Apply(float value, PlayerController player)
    {
        player.armor = (int)value;
        player.UpdatePlayerStatsText();
    }
}

public class DamageIncrease : IApplyAttribute
{
    public void Apply(float value, PlayerController player)
    {
        player.bulletDm = (int)value;
        player.UpdatePlayerStatsText();
    }
}

public class SpeedIncrease : IApplyAttribute
{
    public void Apply(float value, PlayerController player)
    {
        player.speed = value;
        player.UpdatePlayerStatsText();
    }
}

public class FireRateIncrease : IApplyAttribute
{
    public void Apply(float value, PlayerController player)
    {
        player.timeBtwAttack -= value;
        player.UpdatePlayerStatsText();
    }
}

