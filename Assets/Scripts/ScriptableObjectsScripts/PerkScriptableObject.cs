using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName = "Perk", order = 0)]
public class PerkScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;
    public Color BackgroundColor;
    public string[] TypeOfAttributes;
    public float[] values;
}
