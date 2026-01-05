using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Scriptable Objects/ShopItem")]
public class ShopItem : ScriptableObject
{
    public string name;
    private bool isUnlocked = false;
    public bool GetIsUnlocked(){return isUnlocked;}
    public int cost;
}
