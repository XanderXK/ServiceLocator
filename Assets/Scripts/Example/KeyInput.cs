using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInput : IInput
{
    public Vector2 GetMove()
    {
        var direction = Vector2.zero;
        if (Keyboard.current.aKey.isPressed) direction.x = -1;
        if (Keyboard.current.dKey.isPressed) direction.x = 1;
        if (Keyboard.current.wKey.isPressed) direction.y = 1;
        if (Keyboard.current.sKey.isPressed) direction.y = -1;
        return direction;
    }

    public bool GetAction()
    {
        return Keyboard.current.spaceKey.wasPressedThisFrame;
    }
}