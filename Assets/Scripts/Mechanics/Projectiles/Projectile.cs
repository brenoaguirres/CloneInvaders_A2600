using Adventure.Tools.ObjectPool;
using UnityEngine;

public class Projectile : MonoBehaviour, IPoolable
{
    #region FIELDS
    [Header("Settings")]
    private float _moveSpeed = 20f;

    private Rigidbody _rb;
    private ObjectPool<Projectile> _myPool;
    #endregion

    #region UNITY CALLBACKS
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = transform.forward * _moveSpeed;
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
