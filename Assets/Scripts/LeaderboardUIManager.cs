using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUIManager : MonoBehaviour
{
    [SerializeField] private Canvas leaderboardCanvas;
    [SerializeField] private Canvas nameInputCanvas;
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private GameStateReference gameState;

    private void Start()
    {
        bool showNameInput = PlayerPrefs.GetInt("ShowNameInput", 0) == 1;
        nameInputCanvas.gameObject.SetActive(showNameInput);

        mainMenuButton.onClick.AddListener(() =>
        {
            gameState.Value = GameState.Menu;
        });
    }


    public void SubmitName()
    {
        string playerName = nameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
   
            leaderboardManager.UpdatePlayerName(playerName);

           
            nameInputCanvas.gameObject.SetActive(false);
            leaderboardCanvas.gameObject.SetActive(true);

            leaderboardManager.SubmitScore();
        }
        else
        {
            Debug.Log("Name is empty. Please enter a valid name.");
        }
    }
}