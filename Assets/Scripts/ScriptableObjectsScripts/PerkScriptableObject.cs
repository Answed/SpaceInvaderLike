using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName = "Perk", order = 0)]
public class PerkScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;
    public Color BackgroundColor;
    public string[] TypeOfAttributes; // What kind of stat does the Perk add to 
    public float[] values; // How much gets added
    public int rarity; // The higher the value the lower the rarity. Determines how many times this perk is in the selection list.
}
