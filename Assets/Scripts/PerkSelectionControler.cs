using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkSelectionControler : MonoBehaviour
{
    [SerializeField] private GameObject[] perkSelectorObjects;

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
        menuController.EnableGameObjects(perkSelectorObjects);
    }

    public void ClosePerkSelector()
    {
        menuController.DisableGameObjects(perkSelectorObjects);
    }
}
