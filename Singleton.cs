using UnityEngine;

namespace WW.Patterns
{
    /// <summary>
    /// Base Singleton class for guarenteeing singularity and global access.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// Protected accessor
        /// </summary>
        protected static T _instance;

        /// <summary>
        /// Ensure that the singleton is unique.
        /// </summary>
        public static T instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = FindObjectOfType<T>();
                if (_instance != null)
                    return _instance;

                var go = new GameObject(typeof(T).Name);
                _instance = go.AddComponent<T>();
                return _instance;
            }
        }

        /// <summary>
        /// If we're attempting to create a second copy of a Singleton, don't.
        /// Once created add to Don't Destroy On Load to ensure scene persistance.
        /// </summary>
        public virtual void Awake()
        {
            if (_instance != null)
                Destroy(gameObject);
            else
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}