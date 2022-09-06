using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RTS.Core
{
    [Serializable]
    public class GameInput
    {
        [SerializeReference] public IInputProvider Provider = new PCInput();

        [ContextMenu("Reset")]
        private void Reset() => Provider = new PCInput();
    }

    public interface IInputProvider
    {
        Camera Camera { get; }
        
        bool PanCamera { get; }
        bool PanCameraDown { get; }
        bool PanCameraUp { get; }

        bool UnitSelection { get; }
        bool UnitSelectionDown { get; }
        bool UnitSelectionUp { get; }
        
        bool UnitInteractionDown { get; }
        
        bool AdditiveModifier { get; }
        bool SubtractiveModifier { get; }
        bool CameraRotationModifier { get; }
        bool CameraRotationModifierUp { get; }
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
        [SerializeField] private KeyCode _cameraRotationModifier = KeyCode.LeftAlt;

        public Camera Camera => Camera.main;
        public bool PanCamera => Input.GetMouseButton((int)_panCamera);
        public bool PanCameraDown => Input.GetMouseButtonDown((int)_panCamera);
        public bool PanCameraUp => Input.GetMouseButtonUp((int)_panCamera);
        public bool UnitSelectionDown => Input.GetMouseButtonDown((int) _unitSelection);
        public bool UnitSelectionUp => Input.GetMouseButtonUp((int) _unitSelection);
        public bool UnitSelection => Input.GetMouseButton((int) _unitSelection);
        public bool UnitInteractionDown => Input.GetMouseButtonDown((int) _unitInteraction);
        public bool AdditiveModifier => Input.GetKey(_additiveModifier);
        public bool SubtractiveModifier => Input.GetKey(_subtractiveModifier);
        public bool CameraRotationModifier => Input.GetKey(_cameraRotationModifier);
        public bool CameraRotationModifierUp => Input.GetKeyUp(_cameraRotationModifier);

    }
}