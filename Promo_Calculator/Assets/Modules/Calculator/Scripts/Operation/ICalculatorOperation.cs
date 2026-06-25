namespace Modules.Calculator.Scripts.Operation
{
    public interface ICalculatorOperation
    {
        bool CanProcess(string expression);
        CalculationResult Calculate(string expression);
    }
}