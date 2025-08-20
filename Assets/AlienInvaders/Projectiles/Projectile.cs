using AlienInvaders.Tools.ObjectPool;
using UnityEngine;

namespace AlienInvaders.Projectiles
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        #region CONSTANTS
        private const string OBJECT_KILLER_TAG = "ObjectKiller";
        #endregion

        #region FIELDS
        [Header("Settings")]
        private float _moveSpeed = 20f;

        private Rigidbody _rb;
        private ObjectPool<Projectile> _myPool;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            _rb = GetComponentInParent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = transform.up * _moveSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(OBJECT_KILLER_TAG))
            {
                Kill();
            }
        }
        #endregion

        #region CUSTOM METHODS
        public void Reset()
        {
            _rb.linearVelocity = Vector3.zero;
        }
        #endregion

        #region IPoolable IMPLEMENTATION
        public void Kill()
        {
            Reset();
            _myPool.Kill(this);
        }

        public void Spawn<T>(ObjectPool<T> pool) where T : MonoBehaviour, IPoolable
        {
            _myPool = pool as ObjectPool<Projectile>;
            Reset();
        }
        #endregion
    }
}