using System;

namespace Modules.Calculator.Scripts.State.Data
{
    [Serializable]
    public class CalculationResultState
    {
        public string Expression;
        public string Result;

        public CalculationResultState(string expression, string result)
        {
            Expression = expression;
            Result = result;
        }
    }
}