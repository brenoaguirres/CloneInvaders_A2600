using UnityEngine;

namespace AlienInvaders.Tools.Singleton
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region FIELDS
        protected static T _instance;
        #endregion

        #region PROPERTIES
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();

                    if (_instance == null)
                    {
                        GameObject obj = Instantiate(new GameObject(typeof(T).Name + " (Singleton)"), Vector3.zero, Quaternion.identity);
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
        #endregion

        #region UNITY CALLBACKS
        protected void Start()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }
}
