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
            CreatePool(10);
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


        public void CreatePool(int size)
        {
            for (int i = 0; i < size; i++)
            {
                GameObject obj = Instantiate(new GameObject(), transform.position, Quaternion.identity, transform);
                Projectile comp = obj.AddComponent<Projectile>();
                _pool.Add(comp);
                comp.Spawn(this);
                comp.gameObject.SetActive(false);
            }
        }

        public void Kill(T obj)
        {
            if (!_pool.Objects.Contains(obj)) return;

            obj.gameObject.SetActive(false);
            obj.gameObject.transform.position = transform.position;
        }
        #endregion
    }
}
