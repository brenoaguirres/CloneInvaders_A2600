using System;
using System.Collections.Generic;
using UnityEngine;

namespace Adventure.Tools.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        #region FIELDS
        private List<T> _objects = new();
        private GameObject _prefab;
        private Transform _parent;
        #endregion

        #region PROPERTIES
        public List<T> Objects => _objects;
        public Transform Parent { get => _parent; set => _parent = value; }
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
            _objects[0].gameObject.SetActive(true);
            _objects[0].transform.position = position.position;
            return SendToBack(_objects[0]);
        }

        public T SendToBack(T obj)
        {
            if (obj == null || !_objects.Contains(obj)) throw new ArgumentException("Object is null or not in the pool.");

            _objects.RemoveAt(_objects.IndexOf(obj));
            _objects.Add(obj);
            return obj;
        }

        public T SendToFront(T obj)
        {
            if (obj == null || !_objects.Contains(obj)) throw new ArgumentException("Object is null or not in the pool.");

            _objects.RemoveAt(_objects.IndexOf(obj));
            _objects.Insert(0, obj);
            return obj;
        }

        public T GetLast(Transform position)
        {
            if (_objects[^1] == null) return null;
            _objects[^1].gameObject.SetActive(true);
            _objects[^1].transform.position = position.position;
            return SendToFront(_objects[^1]);
        }

        public T Pick(Transform position)
        {
            if (_objects.Count <= 0) return null;
            int index = UnityEngine.Random.Range(0, _objects.Count - 1);
            _objects[index].gameObject.SetActive(true);
            _objects[index].transform.position = position.position;
            return SendToBack(_objects[index]);
        }

        public void CreatePool(int size, Transform transform, GameObject prefab)
        {
            if (transform is null || prefab is null) throw new ArgumentNullException("Parent transform or Prefab can't be null.");

            Parent = transform;
            _prefab = prefab;

            for (int i = 0; i < size; i++)
            {
                GameObject obj = GameObject.Instantiate(prefab, Parent.position, Quaternion.identity, Parent);
                obj.SetActive(false);
            }

            foreach (var instantiatedObject in Parent.GetComponentsInChildren<T>(true))
            {
                Add(instantiatedObject);
            }
        }

        public void Kill(T obj)
        {
            if (!Objects.Contains(obj)) return;
            obj.transform.position = Parent.position;
            obj.gameObject.SetActive(false);
        }
        #endregion
    }
}