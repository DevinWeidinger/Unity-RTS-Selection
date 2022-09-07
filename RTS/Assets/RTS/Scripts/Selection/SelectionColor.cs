using RTS.Core;
using UnityEngine;

namespace RTS.Selection
{
    public class SelectionColor : SelectionListener
    {
        [SerializeField] private MeshRenderer _meshRenderer = default;
        [SerializeField] private ColorSettings _colorSettings = default;
        private Material _defaultMaterial = default;
        private Material _selectionMaterial = default;
        private Material _hoverMaterial = default;
        
        private void Start()
        {
            _defaultMaterial = _meshRenderer.sharedMaterial;
            _selectionMaterial = new Material(_meshRenderer.material) { color = _colorSettings.SelectionColor };
            _hoverMaterial = new Material(_meshRenderer.material) { color = _colorSettings.HoverColor };
        }
        
        protected override void OnSelect() => _meshRenderer.material = _selectionMaterial;
        protected override void OnDeselect() => _meshRenderer.material = _receiver.Hovering ? _hoverMaterial : _defaultMaterial;
        protected override void OnHoverEnter() => _meshRenderer.material = _receiver.Selected ? _selectionMaterial : _hoverMaterial;
        protected override void OnHoverExit() => _meshRenderer.material = _receiver.Selected ? _selectionMaterial : _defaultMaterial;
    }
}
