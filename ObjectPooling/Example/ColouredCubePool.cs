using UnityEngine;

namespace WW.Patterns.Examples
{
    public class ColouredCubePool : PoolablePool
    {
        public PoolableColouredCube prefab;

        protected override PoolableObject CreatePooledItem()
        {
            var poolable = Instantiate(prefab);
            poolable.Pool = Pool;
            return poolable;
        }

        protected override void OnTakeFromPool(PoolableObject obj)
        {
            base.OnTakeFromPool(obj);
            obj.transform.position = Random.insideUnitSphere * 5;
        }
    }
}