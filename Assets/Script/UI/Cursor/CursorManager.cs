using System;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager instance;
    public static CursorManager GetInstance() {return instance;}
    
    [SerializeField] private Texture2D defaultCursorTexture;
    [SerializeField] private Texture2D defaultClickedCursorTexture;
    
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
