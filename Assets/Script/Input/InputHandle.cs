using UnityEngine;
using UnityEngine.InputSystem;
public sealed class InputHandle
{
    public InputAction Input;
    private int Count;

    public InputHandle(InputAction input)
    {
        Input = input;

        if(input == null)
            Debug.Log("Failed to load input from InputAction : " + input);

        Count = 0;
    }

    public void Enable()
    {
        if(Count == 0 && !Input.enabled)
            Input.Enable();

        Count++;
    }

    public void Disable()
    {
        if(Count > 0)
            Count--;

        if(Count == 0 && Input.enabled)
            Input.Disable();
    }

    public bool IsValidToDispose()
    {
        if(Count == 0 && !Input.enabled)
            return true;
        
        
        Debug.Log("Invalid dispose call : have to check where dispatcher didn't unbind");
        return false;
    }

    public bool Dispose()
    {
        if(Count == 0 && !Input.enabled)
        {
            Input = null;
            return true;    
        }
        
        Debug.Log("Invalid dispose call : have to check where dispatcher didn't unbind");
        return false;
    }
}