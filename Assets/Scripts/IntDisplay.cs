using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class IntDisplay : MonoBehaviour
{
    [SerializeField] private IntEventReference intEvent;
    [SerializeField] private TMP_Text text;
    [SerializeField] private string format = "{0}";

    private void OnEnable()
    {
        intEvent.Event.Register(OnIntEvent);
    }

    private void OnDisable()
    {
        intEvent.Event.Unregister(OnIntEvent);
    }

    private void OnIntEvent(int value)
    {
        text.text = string.Format(format, value);
    }
}