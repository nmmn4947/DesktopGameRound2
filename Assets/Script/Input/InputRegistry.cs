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
                Handles.Add(InputActionType.eLeftMouseTapped, new InputHandle(map.FindAction("LeftMouseTapped")));
            
                //Handles.Add(InputActionType.eKeyboardWPressed, new InputHandle(map.FindAction("KeyboardWPressed")));

                // holding input action contains two trigger, when pressed and released
                Handles.Add(InputActionType.eLeftMouseHold, new InputHandle(map.FindAction("LeftMouseHold")));
                //Handles.Add(InputActionType.eRightMouseHolding, new InputHandle(map.FindAction("RightMouseHolding")));

                Handles.Add(InputActionType.eKeyboardWHold, new InputHandle(map.FindAction("KeyboardWHold")));
                Handles.Add(InputActionType.eKeyboardAHold, new InputHandle(map.FindAction("KeyboardAHold")));
                Handles.Add(InputActionType.eKeyboardSHold, new InputHandle(map.FindAction("KeyboardSHold")));
                Handles.Add(InputActionType.eKeyboardDHold, new InputHandle(map.FindAction("KeyboardDHold")));
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
