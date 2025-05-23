using UnityEngine;

namespace Adventure.Tools.ObjectPool
{
    public interface IPoolable
    {
        public void Kill();
        public void Spawn<T>(ObjectPool<T> pool) where T : MonoBehaviour, IPoolable;
    }
}