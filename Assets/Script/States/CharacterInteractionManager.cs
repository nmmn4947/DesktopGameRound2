using Unity.VisualScripting;
using UnityEngine;

public sealed class CharacterInteractionManager : MonoBehaviour
{
    private InteractionSet CurrInteractions = null;
    private InteractionBase FocusedObjectInteraction = null;
    private bool bBound = false;

    public void ChangeInteractions(InteractionSet interactionSet)
    {
        if(CurrInteractions != null)
            CurrInteractions.Dispose();

        FocusedObjectInteraction = null;

        CurrInteractions = interactionSet;
    }

    public void SetFocusedObjectInteraction(InteractionBase interaction) => FocusedObjectInteraction = interaction;

    public void EnableFocusedObjectInteraction()
    {
        if(FocusedObjectInteraction != null)
            CurrInteractions.Enable(FocusedObjectInteraction);
    }
    public void DisableFocusedObjectInteraction() 
    {
        if(FocusedObjectInteraction != null)
            CurrInteractions.Disable(FocusedObjectInteraction);
    }

    void Update()
    {
        if(CurrInteractions != null)
            CurrInteractions.Update();
    }

    void OnDestroy()
    {
        if(CurrInteractions != null)
        {
            CurrInteractions.Dispose();
            CurrInteractions = null;
            FocusedObjectInteraction = null;
        }
    }

    public void GenericEnableAll()
    {
        if(CurrInteractions != null)
            CurrInteractions.GenericEnableAll();
    }
    
    public void DisableAll()
    {
        if(CurrInteractions != null)
            CurrInteractions.DisableAll();
    }
}