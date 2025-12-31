using Unity.VisualScripting;
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

        // when hit object list is not empty
        if(0 < hits.Length)
        { 
            FocusedObject = hits[0].collider.gameObject;
            var interactionManager = FocusedObject.GetComponent<CharacterInteractionManager>();

            // when clicked the same game object, turn the focused off
            if(prev == FocusedObject)
            {
                interactionManager?.DisableFocusedObjectInteraction();
                FocusedObject = null;
                return;   
            }

            interactionManager?.EnableFocusedObjectInteraction();
        }
        // when clicked the empty space, turn the focused off
        else
        {
            if(FocusedObject == null)
                return;

            var interactionManager = FocusedObject.GetComponent<CharacterInteractionManager>();
            interactionManager?.DisableFocusedObjectInteraction();

            FocusedObject = null;                

        }
    }

    // reset the focused object - this function will be used when the game state is changed
    public void ResetFocused()
    {
        if(FocusedObject != null)
        {
            CharacterInteractionManager interactionManager = FocusedObject.GetComponent<CharacterInteractionManager>();
            
            if(interactionManager != null)
                interactionManager.DisableFocusedObjectInteraction();
            
            FocusedObject = null;
        }
    }
    
    public GameObject GetFocusedObject() => FocusedObject; 

    // bind with the dispatcher directly
    public void Enable()
    {
        if(!bBound)
        {
            BoundDispatcher.OnInputOccurred += SetFocusedObject;
            bBound = true;   
        }
    }

    // unbind with the dispatcher 
    public void Disable()
    {
        if(bBound)
        {
            BoundDispatcher.OnInputOccurred -= SetFocusedObject;
            bBound = false;   
        }
    }
}