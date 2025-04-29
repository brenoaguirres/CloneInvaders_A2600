using UnityEngine;
using UnityEngine.Assertions;
using Adventure.Tools.ObjectPool;

namespace Adventure.Mechanics
{
    public class ProjectilePool : MonoBehaviour
    {
        #region FIELDS
        [SerializeField] private GameObject _prefab;
        private ObjectPool<Projectile> _pool = new();
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            Assert.IsNotNull(_prefab, "Prefab is not assigned in the inspector. Please assign a prefab to the ProjectilePool script.");

            _pool.CreatePool(10, transform, _prefab);
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
            Projectile p = _pool.GetFirst(transform);
            p.Spawn(_pool);
            return p;
        }
        #endregion
    }
}
