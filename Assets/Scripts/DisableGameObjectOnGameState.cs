using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class DisableGameObjectOnGameState : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameStateEventReference gameStateEvent;

    private void OnEnable()
    {
        gameStateEvent.Event.Register(OnGameStateEvent);
    }

    private void OnDisable()
    {
        gameStateEvent.Event.Unregister(OnGameStateEvent);
    }

    private void OnGameStateEvent(GameState gameState)
    {
        if (gameState == this.gameState)
        {
            gameObject.SetActive(false);
        }
    }
}