using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Calculator.Scripts.UI.View
{
    public class HistoryPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _historyText;
        [SerializeField] private LayoutElement _layoutElement;
        [Header("Settings")]
        [SerializeField] private int _minHeight;
        [SerializeField] private int _maxHeight;

        private void Awake()
        {
            _layoutElement.minHeight = _minHeight;
        }

        public void SetHistory(string text)
        {
            _historyText.SetText(text);
            var textHeight = _historyText.preferredHeight;
            _layoutElement.preferredHeight = Mathf.Clamp(textHeight, _minHeight, _maxHeight);
        }
    }
}