using UnityEngine;
using UnityEngine.Events;

namespace RTS.Utility
{
    public class HelpToggle : MonoBehaviour
    {
        private int _helpToggle = default;
        [SerializeField] private UnityEvent OnShow = new();
        [SerializeField] private UnityEvent OnHide = new();
        
        private void Awake()
        {
            _helpToggle = PlayerPrefs.GetInt(nameof(HelpToggle), 1);
            Invoke();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10) == false) return;
            _helpToggle = _helpToggle == 0 ? 1 : 0;
            PlayerPrefs.SetInt(nameof(HelpToggle), _helpToggle);
            PlayerPrefs.Save();
            Invoke();
        }

        private void Invoke()
        {
            if(_helpToggle == 0)
                OnHide.Invoke();
            else
                OnShow.Invoke();
        }
    }
}