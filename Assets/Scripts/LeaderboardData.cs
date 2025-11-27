using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public struct LeaderboardEntry
{
    public LeaderboardEntry(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public string Name;
    public int Score;
}

[CreateAssetMenu]
public sealed class LeaderboardData : ScriptableObject
{
    [field: SerializeField, HideInInspector] public List<LeaderboardEntry> Entries { get; private set; }

    private const string SaveFileName = "leaderboard.json";
    private string SaveFilePath => Path.Combine(Application.persistentDataPath, SaveFileName);

    public void Save()
    {
        string json = JsonUtility.ToJson(this, prettyPrint: true);
        File.WriteAllText(SaveFilePath, json);
        Debug.Log($"Leaderboard saved to {SaveFilePath}");
    }

    public void Load()
    {
        if (File.Exists(SaveFilePath))
        {
            string json = File.ReadAllText(SaveFilePath);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("Leaderboard loaded from file.");
        }
        else
        {
            Debug.Log("Save file does not exist.");
            Entries.Clear();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Entries.Clear();
    }

    [ContextMenu("Delete Save File")]
    public void DeleteSaveFile()
    {
        if (File.Exists(SaveFilePath))
        {
            File.Delete(SaveFilePath);
            Debug.Log("Save file deleted.");
        }

        Debug.Log("Save file does not exist.");
    }
}