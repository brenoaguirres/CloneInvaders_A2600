using System.Collections.Generic;
using UnityEngine;

namespace Adventure.Tools.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        #region FIELDS
        private List<T> _objects = new();
        #endregion

        #region PROPERTIES
        public List<T> Objects => _objects;
        #endregion

        #region METHODS
        public void Add(T obj)
        {
            if (!_objects.Contains(obj))
            _objects.Add(obj);
        }

        public void Remove(T obj)
        {
            if (_objects.Contains(obj))
                _objects.Remove(obj);
        }

        public void Clear()
        {
            _objects.Clear();
        }

        public T GetFirst()
        {
            if (_objects[0] == null) return null;
            return _objects[0];
        }

        public T GetLast()
        {
            if (_objects[^1] == null) return null;
            return _objects[^1];
        }

        public T Pick()
        {
            if (_objects.Count <= 0) return null;
            return _objects[UnityEngine.Random.Range(0, _objects.Count - 1)];
        }
        #endregion
    }
}