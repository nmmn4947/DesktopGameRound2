using System;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager instance;
    public static CursorManager GetInstance() {return instance;}
    
    [SerializeField] private Texture2D defaultCursorTexture;
    [SerializeField] private Texture2D defaultClickedCursorTexture;
    
    private CursorBehavior currentBehavior;
    
    [HideInInspector]
    public bool isEquipped = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBehavior != null)
        {
            currentBehavior.CursorLogic(this);
        }
        else
        {
            //default cursor behavior
            //WAIT
            //This might be Universal Cursor Behavior, Like runnin both default and not default
            //guess that depends
            if (Input.GetMouseButton(0))
            {
                Cursor.SetCursor(defaultClickedCursorTexture, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto); // no click
            }
        }
    }

    public void EquipItem(ShopItem item)
    {
        currentBehavior = item._behaviour;
        isEquipped = true;
    }
    
    public void UnequipCurrentItem()
    {
        currentBehavior = null;
        isEquipped = false;
    }
}
