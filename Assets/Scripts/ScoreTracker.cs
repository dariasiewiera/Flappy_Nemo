using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class ScoreTracker : MonoBehaviour
{

    [SerializeField] private IntReference score;

    // Why use colliders when we can just calculate the moment the player passes a pipe?
    [SerializeField] private FloatReference distanceCovered;
    [SerializeField] private FloatReference pipeSpacing;
    [SerializeField] private FloatReference pipeSpawnDistance;

    private float nextPipeDistance;


    private void Start()
    {
        nextPipeDistance = pipeSpawnDistance;
        score.Value = 0;
        distanceCovered.Value = 0f;
    }

    private void Update()
    {
        // If the player has passed a pipe, increment the score

        if (nextPipeDistance > distanceCovered.Value)
        {
            return;
        }

        nextPipeDistance += pipeSpacing.Value;

        score.Value++;
    }
}