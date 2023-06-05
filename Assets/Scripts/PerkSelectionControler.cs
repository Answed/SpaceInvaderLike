using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PerkSelectionControler : MonoBehaviour
{
    private struct PerkButton
    {
        public Button PerkSelectionButton;
        public TextMeshProUGUI PerkDiscription;
        public Image PerkImage;
    }

    [SerializeField] private GameObject perkSelectorObjects;
    [SerializeField] private PerkButton[] perkButtons;

    private MenuController menuController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPerkSelector()
    {
        perkSelectorObjects.SetActive(true);
    }

    public void ClosePerkSelector()
    {
        perkSelectorObjects.SetActive(false);
    }

    private void LoadPerkIntoButton(PerkButton button) 
    {
        // Code for changing the look of a Button based on the selected Perk;
    }

    private void SelectPerkz()
    {
        for(int i = 0; i < 3; i++)
        {
            // Select one random Perk and add it to a list
            LoadPerkIntoButton(perkButtons[i]);
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
    #endregion
}
