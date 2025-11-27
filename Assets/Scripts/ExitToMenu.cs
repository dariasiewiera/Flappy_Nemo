using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitToMenu : MonoBehaviour
{
    [SerializeField] private GameStateReference gameState;
    [SerializeField] private InputAction action;

    private void Awake()
    {
        action.Enable();
    }

    private void OnEnable()
    {
        action.performed += Exit;
    }

    private void OnDisable()
    {
        action.performed -= Exit;
    }

    private void Exit(InputAction.CallbackContext context)
    {
        gameState.Value = GameState.Menu;
    }
}
