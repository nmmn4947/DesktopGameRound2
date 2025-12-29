using UnityEngine;

public sealed class FocusedObjectManager
{
    private static FocusedObjectManager Instance_ = null;

    private GameObject FocusedObject = null;
    private InputManager InputManager_ = null;
    private InputDispatcher BoundDispatcher = null;
    private bool bBound = false;
    private int LayerMask_;

    public static FocusedObjectManager Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new FocusedObjectManager();

        return Instance_;
    }

    private FocusedObjectManager()
    {
        InputManager_ = InputManager.Instance();

        LayerMask_ = ~LayerMask.GetMask("thru");

        BoundDispatcher = InputManager_.InputDispatchers.AddDispatcher(InputActionType.eLeftMousePressed);

        if(BoundDispatcher != null)
            BoundDispatcher.OnInputOccurred += SetFocusedObject;
    }

    public void SetFocusedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager_.CurrMousePos);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, LayerMask_);

        GameObject prev = FocusedObject;

        foreach (var hit in hits)
        {
            FocusedObject = hit.collider.gameObject;
            break;
        }

        if(prev == FocusedObject)
        {
            FocusedObject = null;   
        }
    }

    public void ResetFocused() => FocusedObject = null;
    
    public GameObject GetFocusedObject() => FocusedObject; 

    public void Enable()
    {
        if(!bBound)
        {
            BoundDispatcher.OnInputOccurred += SetFocusedObject;
            bBound = true;   
        }
    }

    public void Disable()
    {
        if(bBound)
        {
            BoundDispatcher.OnInputOccurred -= SetFocusedObject;
            bBound = false;   
        }
    }
}