using UnityEngine;
using UnityEngine.UI; 
using UnityAtoms.BaseAtoms;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private FloatReference distanceCovered;
    [SerializeField] private TMP_Text distanceText;

    private void Update()
    {
        distanceText.text = Mathf.FloorToInt(distanceCovered.Value).ToString();
    }
}

