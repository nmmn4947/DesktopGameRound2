using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Scriptable Objects/ShopItem")]
public class ShopItem : ScriptableObject
{
    [Header("Default Variable")]
    public string displayName;
    public Sprite shopIcon;
    public bool isTool;
    public bool updateCost;
    public int cost;
    [SerializeField] private CursorBehavior behaviour;
    public CursorBehavior _behaviour => behaviour;
    
    [Header("Runtime Variable")]
    public bool isUnlockedInShop;
}