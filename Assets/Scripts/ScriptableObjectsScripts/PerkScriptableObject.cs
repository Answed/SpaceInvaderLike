using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName ="Perk", order = 0)]
public class PerkScriptableObject : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    public Sprite PerkImage;
    public Color BackgroundColor;
    public string StatToUpgrade;
    public float UpgradeValue;
}
