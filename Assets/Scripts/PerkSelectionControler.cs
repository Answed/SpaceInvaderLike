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
    [SerializeField] private PerkScriptableObject[] perks;


    private MenuController menuController;
    private PlayerController playerController;

    private Dictionary<string, IApplyAttribute> attributes;
    private List<PerkScriptableObject> perksList; // Saves all the Perks which are currently in the Selection Pool
    private List<PerkScriptableObject> selectedPerkz;

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
            selectedPerkz.Add(perksList[i]);
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
