using UnityEngine.InputSystem;
public sealed class InputHandle
{
    public InputAction Input;
    private int Count;

    public InputHandle(InputAction input)
    {
        Input = input;
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
}