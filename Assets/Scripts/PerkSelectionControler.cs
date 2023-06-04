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
}
