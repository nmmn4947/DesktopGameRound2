using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class CharacterInteractionManager : MonoBehaviour
{
    private InteractionSet CurrInteractions = null;
    private List<InteractionBase> FocusedInteractions = null;
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

        if(FocusedInteractions != null)
            FocusedInteractions.Clear();
        

        CurrInteractions = interactionSet;
        GenericEnableAll();
    }

    public void SetFocusedInteractions(List<InteractionBase> interactionSet) => FocusedInteractions = interactionSet;

    public void EnableFocusedInteractions()
    {   
        foreach(var focusedInteraction in FocusedInteractions)
            CurrInteractions.Enable(focusedInteraction);
    }
    public void DisableFocusedInteractions() 
    {
        foreach(var focusedInteraction in FocusedInteractions)
            CurrInteractions.Disable(focusedInteraction);
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
            FocusedInteractions.Clear();
            FocusedInteractions = null;
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
            DisableFocusedInteractions();
            bBound = false;   
        }
    }
}