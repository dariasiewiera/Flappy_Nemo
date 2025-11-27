using UnityAtoms.BaseAtoms;
using UnityEngine;

public class NemoFail : MonoBehaviour
{
    [SerializeField] private float linearImpulse;
    [SerializeField] private float angularImpulse;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private GameStateEventReference gameStateEvent;

    private void OnEnable()
    {
        gameStateEvent.Event.Register(OnGameStateChanged);
    }

    private void OnDisable()
    {
        gameStateEvent.Event.Unregister(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.GameOver)
        {
            rigidbody.AddForce(Vector2.left * linearImpulse, ForceMode2D.Impulse);
            rigidbody.AddTorque(angularImpulse, ForceMode2D.Impulse);
        }
    }
}
