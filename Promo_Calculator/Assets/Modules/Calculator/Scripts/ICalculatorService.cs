using UnityEngine;

namespace Modules.Calculator.Scripts
{
    public interface ICalculatorService
    {
        void OpenWindow(Transform uiRoot);
        void CloseWindow();
    }
}