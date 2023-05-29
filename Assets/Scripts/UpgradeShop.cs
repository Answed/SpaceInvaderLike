using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SaveLoadSystem;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    private int points;

    private PlayerUpgrades playerUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPoints()
    {
        points = SaveLoadSystem.SaveSystemManager.LoadScore();
        pointText.text = "Points: " + points;
    }

    public void SavePoints()
    {
        SaveLoadSystem.SaveSystemManager.SaveScore(points);
    }

    public void UpgradeHealth()
    {
        
    }

    private bool CheckPointsAmount(int neededPoints)
    {
        if(points >= neededPoints)
        {
            points -= neededPoints;
            return true;
        }
        else
        {
            Debug.Log("Not Enough Points");
            return false;
        }
    }
}
