using UnityEngine;
using UnityEngine.UIElements;

public class ShopItemBehavior : MonoBehaviour
{
    private ShopItem shopItem { get; set; }
    private CursorManager cursorManager;
    private bool isUnlocked = false;
    
    public bool GetIsUnlocked(){return isUnlocked;}
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursorManager = CursorManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpButton(ShopItem si)
    {
        shopItem = si;
        
    }

    private void CostUpdate()
    {
        
    }

    public void ItemBehaviorUpdate()
    {
        
    }
}
