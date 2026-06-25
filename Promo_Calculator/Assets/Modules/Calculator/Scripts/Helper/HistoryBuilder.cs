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
            if (resultStates == null || resultStates.Count == 0)
            {
                return string.Empty;
            }
            
            _stringBuilder.Clear();

            for (var i = resultStates.Count - 1; i >= 0; i--)
            {
                var resultState = resultStates[i];

                _stringBuilder
                    .Append(resultState.Expression)
                    .Append('=')
                    .Append(resultState.Result);

                if (i > 0)
                {
                    _stringBuilder.AppendLine();
                }
            }

            return _stringBuilder.ToString();
        }
    }
}