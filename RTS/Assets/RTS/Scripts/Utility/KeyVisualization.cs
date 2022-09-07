using RTS.Core;
using TMPro;
using UnityEngine;

namespace RTS.Utility
{
    public class KeyVisualization : MonoBehaviour
    {
        [SerializeField] private TMP_Text _infoText;
        private void Update()
        {
            if (GameData.Instance.Input.Provider.AdditiveModifier)
                _infoText.text = "Additive Modifier Active";
            else if (GameData.Instance.Input.Provider.SubtractiveModifier)
                _infoText.text = "Subtractive Modifier Active";
            else
                _infoText.text = "";
        }
    }
}
