using UnityEngine;

public class HandCursorState : CursorState
{
    public override void Enter()
    {
        
    }

    public override void Do()
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorSprites[1], Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(cursorSprites[0], Vector2.zero, CursorMode.Auto); // no click
        }
    }

    public override void Exit()
    {
        
    }
}
