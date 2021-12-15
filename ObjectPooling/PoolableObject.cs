using UnityEngine;
using UnityEngine.Pool;

namespace WW.Patterns
{
    public class PoolableObject : MonoBehaviour
    {
        public IObjectPool<PoolableObject> Pool { get; set; }

        protected virtual void ReturnToPool()
        {
            Pool.Release(this);
        }

        public virtual void OnPooled()
        {
            //Setting active to false already handled
        }

        public virtual void OnFetched()
        {
            //Setting active to true already handled
        }
    }
}