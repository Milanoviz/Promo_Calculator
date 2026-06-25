using Modules.Calculator.Scripts.Processor;
using Modules.Calculator.Scripts.State;
using Modules.Calculator.Scripts.UI;
using Modules.Calculator.Scripts.UI.Presenter;
using Modules.Calculator.Scripts.UI.View;
using Modules.Notification.Scripts;
using UnityEngine;

namespace Modules.Calculator.Scripts
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorStateService _stateService;
        private readonly ICalculatorProcessor _processor;
        private readonly INotificationService _notificationService;
        
        private ICalculatorWindowPresenter _presenter;

        public CalculatorService(ICalculatorStateService stateService, ICalculatorProcessor processor, INotificationService notificationService)
        {
            _stateService = stateService;
            _processor = processor;
            _notificationService = notificationService;
        }

        public void OpenWindow(Transform uiRoot)
        {
            _presenter ??= CreatePresenter(uiRoot);
            _presenter?.Show();
        }

        public void CloseWindow()
        {
            _presenter?.Hide();
        }

        private ICalculatorWindowPresenter CreatePresenter(Transform root)
        {
            var viewPrefab = Resources.Load<CalculatorWindowView>(AssetPath.WindowView);
            var view = Object.Instantiate(viewPrefab, root);

            return new CalculatorWindowPresenter(view, _processor, _stateService, _notificationService);
        }
    }
}