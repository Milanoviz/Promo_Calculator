using System.Collections.Generic;
using Modules.Calculator.Scripts.State.Data;

namespace Modules.Calculator.Scripts.Helper
{
    public interface IHistoryBuilder
    {
        string Build(IReadOnlyList<CalculationResultState> resultStates);
    }
}