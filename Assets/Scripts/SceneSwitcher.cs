using Eflatun.SceneReference;
using System;
using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneSwitcher : MonoBehaviour
{
    [Serializable]
    private struct Trigger
    {
        public GameState state;
        public SceneReference scene;
    }

    [SerializeField] private GameStateEventReference gameStateChanged;
    [SerializeField] private Trigger[] triggers;

    private void OnEnable()
    {
        gameStateChanged.Event.Register(OnGameStateChanged);
    }

    private void OnDisable()
    {
        gameStateChanged.Event.Unregister(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameState state)
    {
        foreach (var trigger in triggers)
        {
            if (trigger.state == state)
            {
                StartCoroutine(ChangeSceneCoroutine(trigger.scene));
                return;
            }
        }
    }

    private IEnumerator ChangeSceneCoroutine(SceneReference scene)
    {
        // Coroutine in case we would've need a moment to do something before switching scenes.

        SceneManager.LoadScene(scene.BuildIndex);

        yield break;
    }
}