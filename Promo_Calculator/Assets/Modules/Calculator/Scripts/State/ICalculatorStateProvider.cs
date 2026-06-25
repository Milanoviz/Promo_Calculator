using Modules.Calculator.Scripts.State.Data;

namespace Modules.Calculator.Scripts.State
{
    public interface ICalculatorStateProvider
    {
        CalculatorState GetState();
        void SetState(CalculatorState state);
    }
}