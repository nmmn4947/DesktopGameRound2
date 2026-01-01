using UnityEngine;

public sealed class FocusedHandlerManager : MonoBehaviour
{
    public FocusedHandler Handler {get; private set; }

    public void ChangeHandler(FocusedHandler next)
    {
        Handler?.Dispose();
        
        Handler = next;
    }
}