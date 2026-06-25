using System.Collections.Generic;
using System.Text;
using Modules.Calculator.Scripts.State.Data;

namespace Modules.Calculator.Scripts.Helper
{
    public class HistoryBuilder : IHistoryBuilder
    {
        private readonly StringBuilder _stringBuilder = new();
        
        public string Build(IReadOnlyList<CalculationResultState> resultStates)
        {
            if (resultStates == null)
            {
                return string.Empty;
            }
            
            _stringBuilder.Clear();

            foreach (var resultState in resultStates)
            {
                _stringBuilder
                    .Append(resultState.Expression)
                    .Append('=')
                    .AppendLine(resultState.Result);
            }
            
            return _stringBuilder.ToString();
        }
    }
}