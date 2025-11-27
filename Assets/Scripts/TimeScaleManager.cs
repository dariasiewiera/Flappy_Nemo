using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class TimeScaleManager : MonoBehaviour
{
    [SerializeField] private GameStateReference gameState;
    [SerializeField] private FloatReference distanceCovered;

    [SerializeField] private float minTimeScale = 1f;
    [SerializeField] private float maxTimeScale = 2f;
    [SerializeField] private float distanceToMaxTimeScale = 1000f;

    private void Update()
    {
        //if(gameState.Value == GameState.GameOver)
        //{
        //    Time.timeScale = 0;
        //    return;
        //}
       
        if (gameState.Value != GameState.Playing)
        {
            Time.timeScale = 1;
            return;
        }

        float t = Mathf.Clamp01(distanceCovered.Value / distanceToMaxTimeScale); 
        Time.timeScale = Mathf.Lerp(minTimeScale, maxTimeScale, t);

        Debug.Log($"Time.timeScale: {Time.timeScale}");
    }
}
