using System.Collections.Generic;
using UnityEngine;

public sealed class InputManager
{
    private static InputManager Instance_ = null;

    public InputDispatcherManager InputDispatchers = null;
    public Vector2 CurrMousePos { get; private set; }

    public static InputManager Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new();

        return Instance_;
    }

    private InputManager()
    {
        InputDispatchers = new InputDispatcherManager();        
    }

    public void Update()
    {
        CurrMousePos = Input.mousePosition;

        InputDispatchers.Update();
    }

    public void ResetInputDispatcherSet(List<InputActionType> DeletionList)
    {
        if(DeletionList != null)
            foreach(var deletion in DeletionList)
            {
                InputDispatchers.Disable(deletion);
                InputDispatchers.RemoveDispatcher(deletion);   
            }        
    }

    public void SetInputDispatcherSet(List<InputActionType> AdditionList)
    {
        if(AdditionList != null)
            foreach(var addition in AdditionList)
            {
                InputDispatchers.AddDispatcher(addition);
                InputDispatchers.Enable(addition);
            }
    }

    public void ChangeInputDispatcherSet(List<InputActionType> DeletionList, List<InputActionType> AdditionList)
    {
        ResetInputDispatcherSet(DeletionList);
        SetInputDispatcherSet(AdditionList);
    }
}