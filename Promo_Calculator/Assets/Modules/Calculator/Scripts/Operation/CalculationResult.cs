namespace Modules.Calculator.Scripts.Operation
{
    public class CalculationResult
    {
        public bool IsSuccess;
        public string Result;
        public string Expression;
        public string Message;

        public static CalculationResult Success(string result, string expression, string message = null)
        {
            return new CalculationResult
            {
                IsSuccess = true,
                Result = result,
                Expression = expression,
                Message = message ?? string.Empty
            };
        }
        
        public static CalculationResult Failed(string expression, string message)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Result = "ERROR",
                Expression = expression,
                Message = message ?? string.Empty
            };
        }
    }
}