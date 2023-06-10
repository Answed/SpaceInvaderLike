using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PerkSelectionControler : MonoBehaviour
{
    [System.Serializable]
    private struct PerkButton
    {
        public Button PerkSelectionButton;
        public TextMeshProUGUI PerkName;
        public TextMeshProUGUI PerkDiscription;
        public Image PerkImage;
    }

    [SerializeField] private GameObject perkSelectorObjects;
    [SerializeField] private PerkButton[] perkButtons;


    private MenuController menuController;
    private PlayerController playerController;

    private Dictionary<string, IApplyAttribute> attributes;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    public void OpenPerkSelector()
    {
        perkSelectorObjects.SetActive(true);

    }

    public void ClosePerkSelector()
    {
        perkSelectorObjects.SetActive(false);
    }

    private void CreateAttributeList()
    {
        attributes.Add("Health", new MaxHealth());
        attributes.Add("Armor", new Armor());
        attributes.Add("Damage", new DamageIncrease());
        attributes.Add("Speed", new SpeedIncrease()); 
        attributes.Add("FireRate", new FireRateIncrease());
    }

    private void CreatePerkList()
    {

    }

    private void LoadPerkIntoButton(PerkButton button) 
    {
        //Applies all stats to a button based on the selected Perk
    }

    private void SelectPerkz()
    {
        for(int i = 0; i < 3; i++)
        {
            // Select one random Perk and add it to a list
        }
    }

    #region Perk Buttons
    public void PerkShopLeft()
    {
        //Applies the stats from the perk on the left or 0 in the list
    }

    public void PerkShopMiddle()
    {
        //Applies the stats from the perk in the middle or 1 in the list
    }

    public void PerkShopRight()
    {
        //Applies the stats from the perk on the right or 2 in the list
    }

    public void SelectPerk()
    {
        ClosePerkSelector();
    }
    #endregion
}
