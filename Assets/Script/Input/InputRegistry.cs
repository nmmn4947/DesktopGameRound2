using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class InputRegistry
{
    private static InputRegistry Instance_;
    private Dictionary<InputActionType, InputHandle> Handles = new();

    public static InputRegistry Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new InputRegistry();

        return Instance_;
    }

    private InputRegistry()
    {
        InputActionAsset asset = Resources.Load<InputActionAsset>("InputSystem_Actions");

        if(asset != null)
        {
            InputActionMap map = asset.FindActionMap("Controller");

            if(map != null)
            {
                Handles.Add(InputActionType.eLeftMouseTapped, new InputHandle(map.FindAction("LeftMouseTapped")));
                Handles.Add(InputActionType.eLeftMousePressed, new InputHandle(map.FindAction("LeftMousePressed")));

                Handles.Add(InputActionType.eRightMouseTapped, new InputHandle(map.FindAction("RightMouseTapped")));
                Handles.Add(InputActionType.eRightMousePressed, new InputHandle(map.FindAction("RightMousePressed")));

                Handles.Add(InputActionType.eKeyboardWPressed, new InputHandle(map.FindAction("KeyboardWPressed")));
                Handles.Add(InputActionType.eKeyboardAPressed, new InputHandle(map.FindAction("KeyboardAPressed")));
                Handles.Add(InputActionType.eKeyboardSPressed, new InputHandle(map.FindAction("KeyboardSPressed")));
                Handles.Add(InputActionType.eKeyboardDPressed, new InputHandle(map.FindAction("KeyboardDPressed")));
            }
        }
    }

    public InputHandle GetInputHandle(InputActionType type)
    {
        if(Handles.TryGetValue(type, out InputHandle handle))
            return handle;

        return null;        
    }
}
