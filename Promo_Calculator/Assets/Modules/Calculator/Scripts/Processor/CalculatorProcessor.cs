using Modules.Calculator.Scripts.Operation;
using Modules.Calculator.Scripts.Operation.Provider;
using Modules.Calculator.Scripts.State;

namespace Modules.Calculator.Scripts.Processor
{
    public class CalculatorProcessor : ICalculatorProcessor
    {
        private readonly ICalculatorStateService _stateService;
        private readonly ICalculatorOperationProvider _calculatorOperationProvider;

        public CalculatorProcessor(ICalculatorStateService stateService, ICalculatorOperationProvider calculatorOperationProvider)
        {
            _stateService = stateService;
            _calculatorOperationProvider = calculatorOperationProvider;
        }
        
        public CalculationResult Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return CalculationResult.Failed(expression, "Expression is empty");
            }

            var result = TryCalculate(expression);
            SaveToHistory(result);
            return result;
        }
        
        private CalculationResult TryCalculate(string expression)
        {
            if (!_calculatorOperationProvider.TryGetOperation(expression, out var operation))
            {
                return CalculationResult.Failed(expression, "Unknown operation type");
            }

            return operation.Calculate(expression);
        }

        private void SaveToHistory(CalculationResult result)
        {
            _stateService.AddHistoryItem(result.Expression, result.Result);
        }
    }
}