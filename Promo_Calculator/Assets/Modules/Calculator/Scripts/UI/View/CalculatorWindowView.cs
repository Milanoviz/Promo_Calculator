using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Calculator.Scripts.UI.View
{
    public class CalculatorWindowView : MonoBehaviour, ICalculatorWindowView
    {
        public event EventHandler InputChanged;
        public event EventHandler CalculateButtonClicked;
        
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private HistoryPanelView _historyPanelView;
        [SerializeField] private Button _calculateButton;

        public GameObject GameObject => gameObject;

        public void Show()
        {
            _inputField.onValueChanged.AddListener(InputValueChangedHandler);
            _calculateButton.onClick.AddListener(CalculateButtonClickedHandler);
            
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _inputField.onValueChanged.RemoveListener(InputValueChangedHandler);
            _calculateButton.onClick.RemoveListener(CalculateButtonClickedHandler);
            
            gameObject.SetActive(false);
        }
        
        public void SetInput(string input)
        {
            _inputField.text = input;
        }

        public string GetInput()
        {
            return _inputField.text;
        }

        public void SetHistory(string history)
        {
            _historyPanelView.SetHistory(history);
        }

        private void InputValueChangedHandler(string input)
        {
            InputChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CalculateButtonClickedHandler()
        {
            CalculateButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}