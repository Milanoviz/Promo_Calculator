using System.Collections.Generic;
using Modules.Calculator.Scripts.State.Data;

namespace Modules.Calculator.Scripts.State
{
    public class CalculatorStateService : ICalculatorStateService, ICalculatorStateProvider
    {
        private CalculatorState State { get; set; }

        public CalculatorStateService()
        {
            State = new CalculatorState();
        }

        public string GetInput()
        {
            return State.Input;
        }

        public void SetInput(string input)
        {
            State.Input = input;
        }

        public IReadOnlyList<CalculationResultState> GetHistory()
        {
            return State.History;
        }

        public void AddHistoryItem(string expression, string result)
        {
            State.History.Add(new CalculationResultState(expression, result));
        }

        public void ClearHistory()
        {
            State.History.Clear();
        }

        public CalculatorState GetState()
        {
            return State;
        }

        public void SetState(CalculatorState state)
        {
            State = state;
        }
    }
}