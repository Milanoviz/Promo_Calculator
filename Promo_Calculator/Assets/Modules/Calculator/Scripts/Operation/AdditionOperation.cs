using System.Linq;
using System.Text.RegularExpressions;

namespace Modules.Calculator.Scripts.Operation
{
    public class AdditionOperation : ICalculatorOperation
    {
        private static readonly Regex Regex = new(@"^\d+(\+\d+)+$");
        
        public bool CanProcess(string expression)
        {
            return Regex.IsMatch(expression);
        }

        public CalculationResult Calculate(string expression)
        {
            if (!CanProcess(expression))
            {
                return CalculationResult.Failed(expression, "Invalid addition expression");
            }
            
            var numbers = expression.Split('+').Select(int.Parse);
            var result = numbers.Sum();
            
            return CalculationResult.Success(result.ToString(), expression);
        }
    }
}