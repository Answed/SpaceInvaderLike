using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;

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
    [SerializeField] private PerkScriptableObject[] perks;


    private MenuController menuController;
    private PlayerController playerController;

    private Dictionary<string, IApplyAttribute> attributes;
    private List<PerkScriptableObject> perksList; // Saves all the Perks which are currently in the Selection Pool
    private List<int> selectedPerks; // Saves all indexes of the perks which are currently in selection
    private int selectedPerk;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    public void OpenPerkSelector()
    {
        perkSelectorObjects.SetActive(true);
        if (!(perksList.Count > 0) )
            CreatePerkList();
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
        foreach(var perk in perks)
        {
            for (int i = 0;i < perk.rarity; i++)
            {
                perksList.Add(perk);
            }
        }
    }

    private void SelectPerkz()
    {
        for(int i = 0; i < 3; i++)
        {
            var randomPerk = Random.Range(0, perksList.Count);
            selectedPerks.Add(i);
            LoadPerkIntoButton(perkButtons[i], perksList[i]);
        }
    }

    private void LoadPerkIntoButton(PerkButton button, PerkScriptableObject perk)
    {
        button.PerkName.text = perk.Name;
        button.PerkDiscription.text = perk.Description;
        button.PerkImage.sprite = perk.Image;
        button.PerkSelectionButton.gameObject.GetComponent<Image>().color = perk.BackgroundColor;
    }

    private void ApplyPerkToPlayerStats()
    {
        for(int i = 0; i < perksList[selectedPerk].TypeOfAttributes.Length; i++)
        {
            attributes[perksList[selectedPerk].TypeOfAttributes[i]].Apply(perksList[selectedPerk].values[i], playerController);
        }
        RemovePerkFromPerkList(selectedPerk);
    }

    private void RemovePerkFromPerkList(int perkIndex)
    {
        perksList.RemoveAt(perkIndex);
    }

    #region Perk Buttons
    public void PerkShopLeft()
    {
        selectedPerk = selectedPerks[0];
        //Change of overall button color
    }

    public void PerkShopMiddle()
    {
        selectedPerk = selectedPerks[1];
    }

    public void PerkShopRight()
    {
        selectedPerk = selectedPerks[2];
    }

    public void SelectPerk()
    {
        ApplyPerkToPlayerStats();
        ClosePerkSelector();
    }
    #endregion
}
