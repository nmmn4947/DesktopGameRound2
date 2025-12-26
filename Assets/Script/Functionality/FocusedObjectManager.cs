using UnityEngine;

public sealed class FocusedObjectManager
{
    private static FocusedObjectManager Instance_ = null;

    private GameObject FocusedObject = null;

    private MouseInputDispatcher BoundDispatcher = null;
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
        InputManager inputManager = InputManager.Instance();

        LayerMask_ = ~LayerMask.GetMask("thru");

        if(inputManager.InputHandleCommon.Dispatchers.TryGetValue(InputActionType.eLeftMousePressed, out InputDispatcher dispatcher))
            if(dispatcher is MouseInputDispatcher mouseDispatcher)
                BoundDispatcher = mouseDispatcher;
    }

    public void SetFocusedObject(Vector2 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, LayerMask_);

        GameObject prev = FocusedObject;

        foreach (var hit in hits)
        {
            FocusedObject = hit.collider.gameObject;
            break;
        }

        if(prev == FocusedObject)
            FocusedObject = null;
    }

    public void ResetFocused() => FocusedObject = null;
    
    public GameObject GetFocusedObject() => FocusedObject; 

    public void Enable()
    {
        Debug.Log("Bind the function : FocusedManager");

        if(!bBound)
            BoundDispatcher.OnMouseInputOccurred += SetFocusedObject;
    }

    private void Disable()
    {
        if(bBound)
            BoundDispatcher.OnMouseInputOccurred -= SetFocusedObject;
    }
}