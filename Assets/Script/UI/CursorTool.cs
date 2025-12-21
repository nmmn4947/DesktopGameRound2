using UnityEngine;
using UnityEngine.UI;

public class CursorTool : MonoBehaviour
{
    // will rewrite code to make it nicer
    [SerializeField] private Texture2D handCursorSprite;
    [SerializeField] private Texture2D handCursorSpriteClick;

    private bool isHandCursor = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHandCursor && Input.GetMouseButton(0))
        {
            Cursor.SetCursor(handCursorSpriteClick, Vector2.zero, CursorMode.Auto);
        }
        else if (isHandCursor)
        {
            Cursor.SetCursor(handCursorSprite, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void ToggleHandCursor()
    {
        isHandCursor = !isHandCursor;
    }
}
