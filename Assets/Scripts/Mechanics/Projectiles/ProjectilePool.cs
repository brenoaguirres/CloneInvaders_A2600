using UnityEngine;
using Adventure.Tools.ObjectPool;

namespace Adventure.Mechanics
{
    public class ProjectilePool : MonoBehaviour
    {
        #region FIELDS
        private ObjectPool<Projectile> _pool = new();
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            _pool.CreatePool(10);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetFromPool();
            }
        }
        #endregion

        #region CUSTOM METHODS
        public Projectile GetFromPool()
        {
            return _pool.GetFirst(transform);
        }
        #endregion
    }
}
