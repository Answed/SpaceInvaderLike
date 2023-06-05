using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName ="Perk", order = 0)]
public class PerkScriptableObject : ScriptableObject
{
    public string Name;
    [InspectorTextArea]
    public string Description;
    public Image PerkImage;
    public string StatToUpgrade;
    public float UpgradeValue;
}
