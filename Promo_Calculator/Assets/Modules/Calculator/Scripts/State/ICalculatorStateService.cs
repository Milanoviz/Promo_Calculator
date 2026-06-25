using System.Collections.Generic;
using Modules.Calculator.Scripts.State.Data;

namespace Modules.Calculator.Scripts.State
{
    public interface ICalculatorStateService
    {
        string GetInput();
        void SetInput(string input);
        
        IReadOnlyList<CalculationResultState> GetHistory();
        void AddHistoryItem(string expression, string result);
        void ClearHistory();
    }
}