using UnityEngine;
using RTS.Utility;

namespace RTS.Selection
{
    public class SelectionRing : SelectionListener
    {
        [SerializeField] private PoolData _selectionPool = default;
        [SerializeField] private PoolData _hoverPool = default;
        
        private GameObject _selection = default;
        private GameObject _hover = default;
        
        protected override void OnSelect()
        {
            if (_selection != null) return;
            if (_hover) Unload(_hoverPool, ref _hover);
            _selection = Load(_selectionPool);
        }

        protected override void OnDeselect()
        {
            if (_selection == null) return;
            Unload(_selectionPool, ref _selection);
        }

        protected override void OnHoverEnter()
        {
            if (_selection != null || _hover != null) return;
            _hover = Load(_hoverPool);
        }

        protected override void OnHoverExit()
        {
            if (_hover == null) return;
            Unload(_hoverPool, ref _hover);
        }

        private GameObject Load(PoolData pool)
        {
            var instance = pool.Pool.Get();
            instance.transform.SetParent(transform);
            instance.transform.localPosition = default;
            instance.gameObject.SetActive(true);
            return instance;
        }

        private static void Unload(PoolData pool, ref GameObject instance)
        {
            if(instance == null) return;
            pool.Pool.Release(instance);
            instance = null;
        }
    }
}