using Unity.VisualScripting;
using UnityEngine;

public sealed class CharacterInteractionManager : MonoBehaviour
{
    private InteractionSet CurrInteractions = null;
    private InteractionBase FocusedObjectInteraction = null;
    private bool bBound = false;

    // change interaction set
    // when the interaction set is changed, unbind all of interactions with each dispatchers 
    public void ChangeInteractions(InteractionSet interactionSet)
    {
        if(CurrInteractions != null)
        {
            CurrInteractions.DisableAll();
            CurrInteractions.Dispose();
        }

        FocusedObjectInteraction = null;

        CurrInteractions = interactionSet;
        GenericEnableAll();
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
        if(CurrInteractions != null && !bBound)
        {
            CurrInteractions.Dispose();
            CurrInteractions = null;
            FocusedObjectInteraction = null;
        }
    }

    public void GenericEnableAll()
    {
        if(CurrInteractions != null && !bBound)
        {
            CurrInteractions.GenericEnableAll();
            bBound = true;   
        }
    }
    
    public void DisableAll()
    {
        if(CurrInteractions != null && bBound)
        {
            CurrInteractions.DisableAll();
            bBound = false;   
        }
    }
}