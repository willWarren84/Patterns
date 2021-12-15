using UnityEngine;
using UnityEngine.Pool;

namespace WW.Patterns
{
    public class PoolablePool : MonoBehaviour
    {
        public int maxPoolSize = 10;
        public int stackDefaultCapacity = 10;

        private IObjectPool<PoolableObject> pool;

        public IObjectPool<PoolableObject> Pool
        {
            get
            {
                if (pool == null)
                    pool = new ObjectPool<PoolableObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPooledObject, true, stackDefaultCapacity, maxPoolSize);

                return pool;
            }
        }

        protected virtual PoolableObject CreatePooledItem()
        {
            var go = new GameObject();
            var poolable = go.AddComponent<PoolableObject>();
            poolable.Pool = Pool;
            return poolable;
        }

        protected virtual void OnTakeFromPool(PoolableObject obj)
        {
            obj.OnFetched();
            obj.gameObject.SetActive(true);
        }

        protected virtual void OnReturnedToPool(PoolableObject obj)
        {
            obj.OnPooled();
            obj.gameObject.SetActive(false);
        }

        protected virtual void OnDestroyPooledObject(PoolableObject obj)
        {
            Destroy(obj.gameObject);
        }
    }
}
