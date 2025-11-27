using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class DistanceCoveredTracker : MonoBehaviour
{
    [SerializeField] private FloatReference distanceCovered;
    [SerializeField] private FloatReference scrollSpeed;

    private void Update()
    {
        distanceCovered.Value += scrollSpeed.Value * Time.deltaTime;
    }
}
