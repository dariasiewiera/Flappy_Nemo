using UnityAtoms.BaseAtoms;
using UnityEngine;

public sealed class Pipe : MonoBehaviour
{
    [SerializeField] private FloatReference speed;

    [SerializeField] private float destroyX;

    private void Update()
    {
        transform.position += Vector3.left * speed.Value * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}