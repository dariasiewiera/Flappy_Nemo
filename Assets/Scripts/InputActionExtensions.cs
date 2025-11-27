using UnityEngine.InputSystem;

public static class InputActionExtensions
{
    public static InputAction GetAction(this PlayerInput playerInput, InputActionReference reference)
    {
        return playerInput.actions.FindAction(reference.action.id);
    }
}