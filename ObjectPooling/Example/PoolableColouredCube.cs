using UnityEngine;

namespace WW.Patterns.Examples
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PoolableColouredCube : PoolableObject
    {
        MeshRenderer renderer;

        private void Awake()
        {
            renderer = GetComponent<MeshRenderer>();
        }

        public override void OnFetched()
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}