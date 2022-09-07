using System;
using UnityEngine;

namespace RTS.Core
{
    [Serializable]
    public class ColorSettings : ISerializationCallbackReceiver
    {
        [field:SerializeField] public Color SelectionColor { get; private set; } = UnityEngine.Color.red;
        [field:SerializeField] public Color HoverColor { get; private set; } = UnityEngine.Color.yellow;
            
        private static Color _selectionColor = default;
        private static Color _hoverColor = default;
        
        public void OnBeforeSerialize()
        {
            SelectionColor = _selectionColor;
            HoverColor = _hoverColor;
        }

        public void OnAfterDeserialize()
        {
            _selectionColor = SelectionColor;
            _hoverColor = HoverColor;
        }
    }
}