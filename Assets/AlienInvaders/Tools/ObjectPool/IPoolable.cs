using UnityEngine;

namespace AlienInvaders.Tools.ObjectPool
{
    public interface IPoolable
    {
        public void Kill();
        public void Spawn<T>(ObjectPool<T> pool) where T : MonoBehaviour, IPoolable;
    }
}