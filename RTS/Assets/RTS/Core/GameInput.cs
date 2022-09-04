using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RTS
{
    [Serializable]
    public class GameInput
    {
        [SerializeReference] public IInputProvider Provider = new PCInput();
    }

    public interface IInputProvider
    {
        Camera Camera { get; }
        bool PanCamera { get; }
        bool UnitSelectionDown { get; }
        bool UnitSelectionUp { get; }
        bool UnitSelection { get; }
        bool UnitInteractionDown { get; }
        bool AdditiveModifier { get; }
        bool SubtractiveModifier { get; }
    }

    [Serializable]
    public class PCInput : IInputProvider
    {
        [Header("PC Input")]
        [SerializeField] private MouseButton _panCamera = MouseButton.MiddleMouse;
        [SerializeField] private MouseButton _unitSelection = MouseButton.LeftMouse;
        [SerializeField] private MouseButton _unitInteraction = MouseButton.RightMouse;
        [SerializeField] private KeyCode _additiveModifier = KeyCode.LeftShift;
        [SerializeField] private KeyCode _subtractiveModifier = KeyCode.LeftControl;

        public Camera Camera => Camera.main;
        public bool PanCamera => Input.GetMouseButton((int)_panCamera);
        public bool UnitSelectionDown => Input.GetMouseButtonDown((int) _unitSelection);
        public bool UnitSelectionUp => Input.GetMouseButtonUp((int) _unitSelection);
        public bool UnitSelection => Input.GetMouseButton((int) _unitSelection);
        public bool UnitInteractionDown => Input.GetMouseButtonDown((int) _unitInteraction);
        public bool AdditiveModifier => Input.GetKey(_additiveModifier);
        public bool SubtractiveModifier => Input.GetKey(_subtractiveModifier);
    }
}