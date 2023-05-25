using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    private int points;

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
        points = SaveData.LoadScore();
        pointText.text = "Points: " + points;
    }

    public void SavePoints()
    {
        SaveData.SaveScore(points);
    }

    public void UpgradeHealth()
    {

    }
}
