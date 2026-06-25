namespace Modules.Calculator.Scripts.Operation.Provider
{
    public interface ICalculatorOperationProvider
    {
        bool TryGetOperation(string expression, out ICalculatorOperation calculatorOperation);
    }
}