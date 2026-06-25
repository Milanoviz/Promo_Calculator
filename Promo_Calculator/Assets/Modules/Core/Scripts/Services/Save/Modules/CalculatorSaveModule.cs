using Modules.Calculator.Scripts.State;
using Modules.Calculator.Scripts.State.Data;
using UnityEngine;

namespace Modules.Core.Scripts.Services.Save.Modules
{
    public class CalculatorSaveModule : ISaveModule
    {
        public string Id => nameof(CalculatorSaveModule);
        
        private readonly ICalculatorStateProvider _calculatorStateProvider;
        
        public CalculatorSaveModule(ICalculatorStateProvider calculatorStateProvider)
        {
            _calculatorStateProvider = calculatorStateProvider;
        }

        public string ToJson()
        {
            var state = _calculatorStateProvider.GetState();
            return JsonUtility.ToJson(state);
        }

        public void FromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogError($"Error. Json is null or empty");
                return;
            }
            
            var state = JsonUtility.FromJson<CalculatorState>(json);
            _calculatorStateProvider.SetState(state);
        }
    }
}