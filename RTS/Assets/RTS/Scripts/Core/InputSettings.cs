using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RTS.Core
{
    [Serializable]
    public class InputSettings
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
        public bool PanCamera => UnityEngine.Input.GetMouseButton((int)_panCamera);
        public bool PanCameraDown => UnityEngine.Input.GetMouseButtonDown((int)_panCamera);
        public bool PanCameraUp => UnityEngine.Input.GetMouseButtonUp((int)_panCamera);
        public bool UnitSelectionDown => UnityEngine.Input.GetMouseButtonDown((int) _unitSelection);
        public bool UnitSelectionUp => UnityEngine.Input.GetMouseButtonUp((int) _unitSelection);
        public bool UnitSelection => UnityEngine.Input.GetMouseButton((int) _unitSelection);
        public bool UnitInteractionDown => UnityEngine.Input.GetMouseButtonDown((int) _unitInteraction);
        public bool AdditiveModifier => UnityEngine.Input.GetKey(_additiveModifier);
        public bool SubtractiveModifier => UnityEngine.Input.GetKey(_subtractiveModifier);
        public bool CameraRotationModifier => UnityEngine.Input.GetKey(_cameraRotationModifier);
        public bool CameraRotationModifierUp => UnityEngine.Input.GetKeyUp(_cameraRotationModifier);

    }
}