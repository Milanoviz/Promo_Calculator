using System.Collections.Generic;

namespace Modules.Calculator.Scripts.Operation.Provider
{
    public class CalculatorOperationProvider : ICalculatorOperationProvider
    {
        private readonly IEnumerable<ICalculatorOperation> _operations;

        public CalculatorOperationProvider(IEnumerable<ICalculatorOperation> operations)
        {
            _operations = operations;
        }

        public bool TryGetOperation(string expression, out ICalculatorOperation result)
        {
            foreach (var operation in _operations)
            {
                if (!operation.CanProcess(expression))
                    continue;
 
                result = operation;
                return true;
            }
            
            result = null;
            return false;
        }
    }
}