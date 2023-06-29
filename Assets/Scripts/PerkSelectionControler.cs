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

    private PlayerController playerController;
    private GameManager gameManager;

    private Dictionary<string, IApplyAttribute> attributes;
    private List<PerkScriptableObject> perksList; // Saves all the Perks which are currently in the Selection Pool
    private List<int> selectedPerks; // Saves all indexes of the perks which are currently in selection
    private int selectedPerk;

    // Start is called before the first frame update
    void Start()
    {
        perksList = new List<PerkScriptableObject>();
        selectedPerks = new List<int>();
        attributes = new Dictionary<string, IApplyAttribute>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GetComponent<GameManager>();
    }

    public void OpenPerkSelector()
    {
        perkSelectorObjects.SetActive(true);
        if (!(perksList.Count > 0))
        {
            CreatePerkList();
            CreateAttributeList();
        }
        
        SelectPerks();
    }

    public void ClosePerkSelector()
    {
        perkSelectorObjects.SetActive(false);
        gameManager.gameIsActive = true;
    }

    private void CreateAttributeList()
    {
        MaxHealth maxHealth = new MaxHealth();
        Armor armor = new Armor();
        DamageIncrease damage = new DamageIncrease();
        SpeedIncrease speed = new SpeedIncrease();
        FireRateIncrease fireRate = new FireRateIncrease();
        UpgradeDuration upgradeDuration = new UpgradeDuration();

        attributes.Add("Health", maxHealth);
        attributes.Add("Armor", armor);
        attributes.Add("Damage", damage);
        attributes.Add("Speed", speed); 
        attributes.Add("FireRate", fireRate);
        attributes.Add("Duration", upgradeDuration);
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

    private void SelectPerks()
    {
        int perksForButtonAvailable = CheckAmountOfPerks();
        for(int i = 0; i < perksForButtonAvailable; i++)
        {
            var randomPerk = Random.Range(0, perksList.Count);
            selectedPerks.Add(randomPerk);
            LoadPerkIntoButton(perkButtons[i], perksList[randomPerk]);
        }
    }

    private int CheckAmountOfPerks()
    {
        if (perksList.Count >= 3)
            return 3;
        else if (perksList.Count == 2)
            return 2;
        else if (perksList.Count == 1) 
            return 1;
        else return 0;
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
        perksList.RemoveAt(selectedPerk);
        selectedPerks.Remove(selectedPerk);
        
    }

    #region Perk Buttons
    public void PerkShopLeft()
    {
        selectedPerk = selectedPerks[0];
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
