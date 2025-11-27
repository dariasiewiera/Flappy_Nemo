using System.Linq;
using UnityEngine;

public sealed class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] private LeaderboardEntryDisplay entryPrefab;

    [SerializeField] private Transform entryParent;

    public void SetData(LeaderboardData leaderboard)
    {
        foreach (Transform child in entryParent)
        {
            Destroy(child.gameObject);
        }

        var sortedEntries = leaderboard.Entries.OrderByDescending(entry => entry.Score).ToList();
        
        int entriesToDisplay = Mathf.Min(sortedEntries.Count, 10);

        for (int i = 0; i < entriesToDisplay; i++)
        {
            var entryDisplay = Instantiate(entryPrefab, entryParent);
            entryDisplay.SetEntry(sortedEntries[i]);
        }

    }
}