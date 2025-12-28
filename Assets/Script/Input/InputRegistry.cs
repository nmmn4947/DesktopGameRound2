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
                // pressed input action contains one trigger, when pressed
                // will be used to check collided game object by raycasting when pressed
                Handles.Add(InputActionType.eLeftMousePressed, new InputHandle(map.FindAction("LeftMousePressed")));
                Handles.Add(InputActionType.eRightMousePressed, new InputHandle(map.FindAction("RightMousePressed")));
            
                Handles.Add(InputActionType.eKeyboardWPressed, new InputHandle(map.FindAction("KeyboardWPressed")));

                // holding input action contains two trigger, when pressed and released
                Handles.Add(InputActionType.eLeftMouseHolding, new InputHandle(map.FindAction("LeftMouseHolding")));
                Handles.Add(InputActionType.eRightMouseHolding, new InputHandle(map.FindAction("RightMouseHolding")));

                Handles.Add(InputActionType.eKeyboardWHolding, new InputHandle(map.FindAction("KeyboardWHolding")));
                Handles.Add(InputActionType.eKeyboardAHolding, new InputHandle(map.FindAction("KeyboardAHolding")));
                Handles.Add(InputActionType.eKeyboardSHolding, new InputHandle(map.FindAction("KeyboardSHolding")));
                Handles.Add(InputActionType.eKeyboardDHolding, new InputHandle(map.FindAction("KeyboardDHolding")));
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
