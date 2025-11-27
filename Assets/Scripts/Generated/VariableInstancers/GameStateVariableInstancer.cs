using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `GameState`. Inherits from `AtomVariableInstancer&lt;GameStateVariable, GameStatePair, GameState, GameStateEvent, GameStatePairEvent, GameStateGameStateFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/GameState Variable Instancer")]
    public class GameStateVariableInstancer : AtomVariableInstancer<
        GameStateVariable,
        GameStatePair,
        GameState,
        GameStateEvent,
        GameStatePairEvent,
        GameStateGameStateFunction>
    { }
}
