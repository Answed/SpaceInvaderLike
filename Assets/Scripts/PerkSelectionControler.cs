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
    [SerializeField] private PerkScriptableObject[] perkz;


    private MenuController menuController;
    private List<PerkScriptableObject> perkzList;
    private List<PerkScriptableObject> selectedPerkz;

    // Start is called before the first frame update
    void Start()
    {
        perkzList = new List<PerkScriptableObject>();
        selectedPerkz = new List<PerkScriptableObject>();
    }

    public void OpenPerkSelector()
    {
        perkSelectorObjects.SetActive(true);
        if(perkzList.Count == 0 ) //List ónly gets created ones
            CreatePerkList();
    }

    public void ClosePerkSelector()
    {
        perkSelectorObjects.SetActive(false);
    }

    private void CreatePerkList()
    {
        foreach (PerkScriptableObject perk in perkzList)
        {
            for (int counter = 0; counter < perk.TimesInList; counter++)
            {
                perkzList.Add(perk);
            }
        }
    }

    private void LoadPerkIntoButton(PerkButton button, PerkScriptableObject selectedPerk) 
    {
        button.PerkSelectionButton.GetComponent<Image>().color = selectedPerk.BackgroundColor;
        button.PerkName.text = selectedPerk.Name;
        button.PerkDiscription.text = selectedPerk.Description;
        button.PerkImage.sprite = selectedPerk.PerkImage;
    }

    private void SelectPerkz()
    {
        for(int i = 0; i < 3; i++)
        {
            // Select one random Perk and add it to a list
            var randomPerk = Random.Range(0, perkzList.Count-1);
            LoadPerkIntoButton(perkButtons[i], perkzList[randomPerk]);
            selectedPerkz.Add(perkzList[randomPerk]);
            perkzList.RemoveAt(randomPerk);
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
