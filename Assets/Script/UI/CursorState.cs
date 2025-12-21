using UnityEngine;
using System.Collections.Generic;

public abstract class CursorState : MonoBehaviour
{
    [SerializeField] protected List<Texture2D> cursorSprites = new List<Texture2D>();
    public abstract void Enter();
    public abstract void Do();
    public abstract void Exit();
    
    /*if (isHandCursor && Input.GetMouseButton(0))
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
    }*/

}
