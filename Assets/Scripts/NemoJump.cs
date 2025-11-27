using UnityAtoms.BaseAtoms;
using UnityEngine;

public class NemoJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private VoidBaseEventReference jumpEvent;
    [SerializeField] private GameStateReference gameState;

    private void OnEnable()
    {
        jumpEvent.Event.Register(Jump);
    }

    private void OnDisable()
    {
        jumpEvent.Event.Unregister(Jump);
    }

    public void Jump()
    {
        rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 0);
        rigidbody.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
    private void GameOver()
    {

        gameState.Value = GameState.GameOver;
        Debug.Log("Game Over!");
    }
}
