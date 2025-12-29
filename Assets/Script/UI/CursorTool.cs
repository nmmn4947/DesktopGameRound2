using UnityEngine;
using UnityEngine.UI;

public class CursorTool : MonoBehaviour
{
    // will rewrite code to make it nicer
    [SerializeField] private HandCursorState handCursorState;
    
    private bool toolIsSelected = false;
    private CursorState currentCursorState;

    public bool GetIfToolIsSelected(){return toolIsSelected;}
    public CursorState GetCurrentCursorState(){return currentCursorState;}
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCursorState != null)
        {
            currentCursorState.Do();
        }
        else
        {
            //default cursor
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    void ToggleCursor(CursorState cursorState)
    {
        toolIsSelected = !toolIsSelected;
        if (toolIsSelected)
        {
            if (currentCursorState != null)
            {
                currentCursorState.Exit();
            }
            currentCursorState = cursorState;
            currentCursorState.Enter();
        }
        else
        {
            currentCursorState.Exit();
            currentCursorState = null;
        }
    }
    
    public void ToggleHandCursor()
    {
        ToggleCursor(handCursorState);
    }
}
