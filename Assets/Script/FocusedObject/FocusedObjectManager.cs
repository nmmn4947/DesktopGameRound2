using System.Runtime.InteropServices;
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
    }

    public void SetFocusedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager_.CurrMousePos);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, LayerMask_);

        GameObject prev = FocusedObject;

        // when hit object list is not empty
        if(0 < hits.Length)
        { 
            var next = hits[0].collider.gameObject;

            // when clicked the same game object, turn the focused off
            if(prev == next)
            {
                //prev?.GetComponent<FocusedHandlerManager>()?.Handler?.UnFocused();
                //FocusedObject = null;
                return;   
            }
            
            prev?.GetComponent<FocusedHandlerManager>()?.Handler?.UnFocused();

            FocusedObject = next;
            FocusedObject?.GetComponent<FocusedHandlerManager>()?.Handler?.Focused();
        }
        // when clicked the empty space, turn the focused off
        else
        {
            if(FocusedObject == null)
                return;

            FocusedObject?.GetComponent<FocusedHandlerManager>()?.Handler?.UnFocused();   
            FocusedObject = null;
        }
    }

    // reset the focused object - this function will be used when the game state is changed
    public void ResetFocused()
    {
        if(FocusedObject != null)
        {
            FocusedObject?.GetComponent<FocusedHandlerManager>()?.Handler?.UnFocused();
            FocusedObject = null;
        }
    }
    
    public GameObject GetFocusedObject() => FocusedObject; 

    // bind with the dispatcher directly
    public void Enable()
    {
        if(!bBound)
        {
            Debug.Log("Focused Object Enable");
            BoundDispatcher.Bind(null, SetFocusedObject, null);
            bBound = true;   
        }
    }

    // unbind with the dispatcher 
    public void Disable()
    {
        if(bBound)
        {
            Debug.Log("Focused Object Disable");
            BoundDispatcher.Unbind(null, SetFocusedObject, null);
            bBound = false;   
        }
    }
}