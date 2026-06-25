using Modules.Core.Scripts.Commands;
using Modules.Core.Scripts.Services;
using Modules.Core.Scripts.Services.Save;
using Modules.DI.Scripts;
using UnityEngine;

namespace Modules.Core.Scripts
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private IDiContainer _diContainer;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            _diContainer = new DiContainer();
            var projectInstaller = new ProjectInstaller(_diContainer, this);
            projectInstaller.Install();
            
            var runApplicationCommand = new RunApplicationCommand(_diContainer);
            runApplicationCommand.Execute();
        }

        private void OnDestroy()
        {
            var saveService = _diContainer.Resolve<ISaveService>();
            saveService?.Save();
        }
    }
}