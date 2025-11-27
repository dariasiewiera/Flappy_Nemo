using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class NemoInput : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private VoidBaseEventReference onJump;

    private void OnEnable()
    {
        playerInput.GetAction(jumpAction).performed += OnJump;
    }

    private void OnDisable()
    {
        playerInput.GetAction(jumpAction).performed -= OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        onJump.Event.Raise();
    }
}