using System;
using UnityEngine;

namespace Modules.Calculator.Scripts.UI.View
{
    public interface ICalculatorWindowView
    {
        event EventHandler InputChanged;
        event EventHandler CalculateButtonClicked;

        GameObject GameObject { get; }
        
        void Show();
        void Hide();
        
        void SetInput(string input);
        string GetInput();
        
        void SetHistory(string history);
    }
}