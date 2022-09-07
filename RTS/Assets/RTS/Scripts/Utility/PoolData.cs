using UnityEngine;
using UnityEngine.Pool;

namespace RTS.Utility
{
    [CreateAssetMenu]
    public class PoolData : ScriptableObject
    {
        [SerializeField] private GameObject _prefab = default;
        [SerializeField] private int _size = default;
        [SerializeField] private int _maxSize = default;
        
        public ObjectPool<GameObject> Pool
        {
            get
            {
                if (_container == null)
                    Build();
                return _pool;
            }
        }

        private ObjectPool<GameObject> _pool = default;
        private GameObject _container = default;

        private void Build()
        {
            _pool = new ObjectPool<GameObject>(CreateInstance, Get, Release, Destroy, true, _size, _maxSize);
            ValidateContainer();
        }

        private GameObject CreateInstance()
        {
            ValidateContainer();
            var instance = Instantiate(_prefab, _container.transform);
            instance.SetActive(false);
            return instance;
        }

        private static void Get(GameObject get)
        {
            if (get == null) Debug.LogWarning($"Fetched null object.");
        }

        private void Release(GameObject release)
        {
            release.SetActive(false);
            release.transform.SetParent(_container.transform);
        }
        
        private static void Destroy(GameObject gameObject) => Object.Destroy(gameObject);

        private void ValidateContainer()
        {
            if (_container == null) _container = new GameObject($"ObjectPool:{_prefab.name}");
        }
    }
}