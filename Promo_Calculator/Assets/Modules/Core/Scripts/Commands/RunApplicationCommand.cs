using Modules.Calculator.Scripts;
using Modules.Core.Scripts.Services.Save;
using Modules.Core.Scripts.Services.Scene;
using Modules.Core.Scripts.Services.Scene.Data;
using Modules.DI.Scripts;
using UnityEngine;

namespace Modules.Core.Scripts.Commands
{
    public class RunApplicationCommand : ICommand
    {
        private readonly ISaveService _saveService;
        private readonly ISceneService _sceneService;
        private readonly ICalculatorService _calculatorService;
        
        public RunApplicationCommand(IDiContainer diContainer)
        {
            _saveService = diContainer.Resolve<ISaveService>();
            _sceneService = diContainer.Resolve<ISceneService>();
            _calculatorService = diContainer.Resolve<ICalculatorService>();
        }

        public void Execute()
        {
            _saveService.Load();
            _sceneService.LoadScene(SceneConstantData.MainSceneName, OnMainSceneLoaded);
        }

        private void OnMainSceneLoaded()
        {
            var uiRoot = CreateUiRoot();
            _calculatorService.OpenWindow(uiRoot.transform);
        }

        private GameObject CreateUiRoot()
        {
            var uiRootPrefab = Resources.Load<GameObject>("UIRoot");
            return Object.Instantiate(uiRootPrefab);
        }
    }
}