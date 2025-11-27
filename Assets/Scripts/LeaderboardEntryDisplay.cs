using TMPro;
using UnityEngine;

public sealed class LeaderboardEntryDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text entryName;
    [SerializeField] private TMP_Text entryScore;

    public void SetEntry(LeaderboardEntry entry)
    {
        entryName.text = entry.Name;
        entryScore.text = entry.Score.ToString();
    }
}