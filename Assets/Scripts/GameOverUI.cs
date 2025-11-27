using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameStateReference gameState;
    [SerializeField] private GameStateEventReference gameStateChanged;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private Button submitScoreButton;
    [SerializeField] private LeaderboardData leaderboardData;
    [SerializeField] private IntReference score; 
    private const int MaxEntries = 10;
    private void Start()
    {
        Hide();
        gameStateChanged.Event.Register(OnGameStateChange);
    }

    private void OnDestroy()
    {
        gameStateChanged.Event.Unregister(OnGameStateChange); 
    }

    private void OnGameStateChange()
    {
        if (gameState.Value == GameState.GameOver)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);
        mainMenuButton.onClick.RemoveAllListeners();
        leaderboardButton.onClick.RemoveAllListeners();
        submitScoreButton.gameObject.SetActive(false);

        bool canEnterLeaderboard = IsScoreGoodEnough(score.Value);

        if (canEnterLeaderboard)
        {
            submitScoreButton.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(submitScoreButton.gameObject);

            submitScoreButton.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("ShowNameInput", 1);
                gameState.Value = GameState.Leaderboard;
            });
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(mainMenuButton.gameObject);
        }

        mainMenuButton.onClick.AddListener(() =>
        {
            gameState.Value = GameState.Menu;
        });

        leaderboardButton.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("ShowNameInput", 0);
            gameState.Value = GameState.Leaderboard;
        });
    }

    private bool IsScoreGoodEnough(int newScore)
    {
        if (newScore <= 0) return false;

        leaderboardData.Load();

        if (leaderboardData.Entries.Count < MaxEntries) return true;
           
        int lowestScore = leaderboardData.Entries.Min(entry => entry.Score);
        return newScore > lowestScore;
    }

    void Hide()
    {
        submitScoreButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
