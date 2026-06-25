using System;
using System.Collections.Generic;

namespace Modules.Calculator.Scripts.State.Data
{
    [Serializable]
    public class CalculatorState
    {
        public string Input;
        public List<CalculationResultState> History = new();
    }
}