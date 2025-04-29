using System.Collections.Generic;
using UnityEngine;

namespace Adventure.Tools.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        #region FIELDS
        private List<T> _objects = new();
        private GameObject _prefab;
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

        public T GetFirst(Transform position)
        {
            if (_objects[0] == null) return null;
            _objects[0].transform.position = position.position;
            _objects[0].gameObject.SetActive(true);
            return _objects[0];
        }

        public T GetLast(Transform position)
        {
            if (_objects[^1] == null) return null;
            _objects[^1].transform.position = position.position;
            _objects[^1].gameObject.SetActive(true);
            return _objects[^1];
        }

        public T Pick(Transform position)
        {
            if (_objects.Count <= 0) return null;
            int index = UnityEngine.Random.Range(0, _objects.Count - 1);
            _objects[index].transform.position = position.position;
            _objects[index].gameObject.SetActive(true);
            return _objects[index];
        }
        #endregion
    }
}