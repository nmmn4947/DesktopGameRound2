using Unity.VisualScripting;
using UnityEngine;

public sealed class CharacterInteractionManager : MonoBehaviour
{
    private InteractionSet CurrInteractions = null;

    private bool bBound = false;

    public void ChangeInteractions(InteractionSet interactionSet)
    {
        if(CurrInteractions != null)
        {
            CurrInteractions.Disable();
            CurrInteractions.Dispose();   
        }

        CurrInteractions = interactionSet;
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
        }
    }

    public void Enable()
    {
        if(CurrInteractions != null)
        {
            CurrInteractions.Enable();

            if(CurrInteractions.IsBound() && !bBound)
                bBound = true;   
        }
    }
    
    public void Disable()
    {
        if(CurrInteractions != null)
        {
            CurrInteractions.Disable();
            
            if(!CurrInteractions.IsBound() && bBound)
                bBound = false;   
        }
    }
}