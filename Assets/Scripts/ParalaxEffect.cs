using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private new Renderer renderer;
    [SerializeField] private float factor = 1.0f;
    [SerializeField] private FloatReference offset;

    [SerializeField] private string offsetShaderProperty = "_MainTex_ST";

    private MaterialPropertyBlock materialPropertyBlock;

    private void Awake()
    {
        materialPropertyBlock = new();
    }

    private void Update()
    {
        renderer.GetPropertyBlock(materialPropertyBlock);

        materialPropertyBlock.SetFloat(offsetShaderProperty, offset.Value * factor);

        renderer.SetPropertyBlock(materialPropertyBlock);
    }
}