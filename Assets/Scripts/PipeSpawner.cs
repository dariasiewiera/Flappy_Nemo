using UnityAtoms.BaseAtoms;
using UnityEngine;

public readonly struct PipesSpawnInfo
{
    public readonly float GapHeight;
    public readonly float GapSize;

    public PipesSpawnInfo(float gapHeight, float gapSize)
    {
        GapHeight = gapHeight;
        GapSize = gapSize;
    }
}

public sealed class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Pipe pipePrefab;
    [SerializeField] private FloatReference spawnDistance;
    [SerializeField] private FloatReference distanceCovered;
    [SerializeField] private FloatReference pipeSpacing;

    // As these won't be used elsewhere, let's use regular variables.
    [SerializeField] private float minGapHeight = 1f;
    [SerializeField] private float maxGapHeight = 3f;
    [SerializeField] private float gapSize = 1f;

    private float nextDistanceCovered = 0;

    private void Update()
    {
        if (nextDistanceCovered > distanceCovered.Value)
        {
            return;
        }

        nextDistanceCovered += pipeSpacing.Value;

        float randomGapHeight = Random.Range(minGapHeight, maxGapHeight);

        PipesSpawnInfo pipesSpawnInfo = new PipesSpawnInfo(randomGapHeight, gapSize);
        SpawnPipes(pipesSpawnInfo);
        
    }

    public void SpawnPipes(PipesSpawnInfo pipesSpawnInfo)
    {
        float topPipeY = pipesSpawnInfo.GapHeight + pipesSpawnInfo.GapSize / 2;
        float bottomPipeY = pipesSpawnInfo.GapHeight - pipesSpawnInfo.GapSize / 2;

      
        Instantiate(pipePrefab, new Vector3(spawnDistance.Value, topPipeY, 0), Quaternion.Euler(0, 0, 180));
        Instantiate(pipePrefab, new Vector3(spawnDistance.Value, bottomPipeY, 0), Quaternion.identity);
    }
}