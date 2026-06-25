using System.Collections.Generic;
using Modules.Calculator.Scripts;
using Modules.Calculator.Scripts.Operation;
using Modules.Calculator.Scripts.Operation.Provider;
using Modules.Calculator.Scripts.Processor;
using Modules.Calculator.Scripts.State;
using Modules.Core.Scripts.Services;
using Modules.Core.Scripts.Services.Save;
using Modules.Core.Scripts.Services.Save.Modules;
using Modules.Core.Scripts.Services.Scene;
using Modules.DI.Scripts;
using Modules.Notification.Scripts;

namespace Modules.Core.Scripts
{
    public class ProjectInstaller
    {
        private readonly IDiContainer _diContainer;
        private readonly ICoroutineRunner _coroutineRunner;

        public ProjectInstaller(IDiContainer diContainer, ICoroutineRunner coroutineRunner)
        {
            _diContainer = diContainer;
            _coroutineRunner = coroutineRunner;
        }

        public void Install()
        {
            _diContainer.Bind<ISceneService>(new SceneService(_coroutineRunner));
            
            var saveService = new SaveService();
            _diContainer.Bind<ISaveService>(saveService);
            
            InstallNotificationModule();
            InstallCalculatorModule();
        }

        private void InstallNotificationModule()
        {
            _diContainer.Bind<INotificationService>(new NotificationService());
        }

        private void InstallCalculatorModule()
        {
            var stateService = new CalculatorStateService();
            var calculatorOperations = new List<ICalculatorOperation>()
            {
                new AdditionOperation()
            };
            
            var calculatorProcessor = new CalculatorProcessor(stateService, new CalculatorOperationProvider(calculatorOperations));
            var notificationService = _diContainer.Resolve<INotificationService>();
            
            _diContainer.Bind<ICalculatorService>(new CalculatorService(stateService, calculatorProcessor, notificationService));
            
            var saveService = _diContainer.Resolve<ISaveService>();
            saveService.RegisterModule(new CalculatorSaveModule(stateService));
        }
    }
}