using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Scriptable Objects/ShopItem")]
public class ShopItem : ScriptableObject
{
    public string name;
    public bool isTool;
    public bool updateCost;
    public int cost;
    public CursorBehavior behaviour;
}