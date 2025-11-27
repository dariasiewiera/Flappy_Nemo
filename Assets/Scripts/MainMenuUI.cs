using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityAtoms.BaseAtoms;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private GameStateReference gameState;

    private void Awake()
    {
        gameState.Value = GameState.Menu;

        playButton.onClick.AddListener(() =>
        {
            gameState.Value = GameState.Playing;
        });

        leaderboardButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("ShowNameInput", 0);
            gameState.Value = GameState.Leaderboard;
        });

        Time.timeScale = 1f;
    }
}