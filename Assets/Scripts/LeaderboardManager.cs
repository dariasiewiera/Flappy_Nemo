using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private LeaderboardData data;
    [SerializeField] private IntReference score;
    [SerializeField] private StringReference playerName;

    [SerializeField] private LeaderboardDisplay display;

    private void Start()
    {
        data.Load(); ///////
        display.SetData(data);
    }
    public void UpdatePlayerName(string inputName)
    {
        playerName.Value = inputName;
    }
    public void SubmitScore()
    {
        data.Entries.Add(new LeaderboardEntry(playerName.Value, score.Value));
        data.Entries.Sort((entry1, entry2) => entry2.Score.CompareTo(entry1.Score)); /////
        while (data.Entries.Count > 10)
        {
            data.Entries.RemoveAt(data.Entries.Count - 1);
        }
        display.SetData(data);
        data.Save();
    }
}