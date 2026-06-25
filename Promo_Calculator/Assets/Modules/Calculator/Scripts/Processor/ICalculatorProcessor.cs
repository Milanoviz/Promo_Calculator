using Modules.Calculator.Scripts.Operation;

namespace Modules.Calculator.Scripts.Processor
{
    public interface ICalculatorProcessor
    {
        CalculationResult Calculate(string expression);
    }
}