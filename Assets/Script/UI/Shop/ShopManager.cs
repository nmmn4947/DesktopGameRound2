using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> allShopItem = new List<ShopItem>();
    public GameObject shopItemPrefabs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Spawn Shop Item Prefabs for each allShopItem, and set up each of them with proper item data from ShopItemBehavior
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
