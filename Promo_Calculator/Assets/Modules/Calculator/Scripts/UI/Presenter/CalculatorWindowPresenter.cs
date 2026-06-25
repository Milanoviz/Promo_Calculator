using System;
using System.Collections.Generic;
using Modules.Calculator.Scripts.Helper;
using Modules.Calculator.Scripts.Processor;
using Modules.Calculator.Scripts.State;
using Modules.Calculator.Scripts.State.Data;
using Modules.Calculator.Scripts.UI.View;
using Modules.Notification.Scripts;

namespace Modules.Calculator.Scripts.UI.Presenter
{
    public class CalculatorWindowPresenter : ICalculatorWindowPresenter
    {
        private readonly ICalculatorWindowView _view;
        private readonly ICalculatorProcessor _calculatorProcessor;
        private readonly ICalculatorStateService _stateService;
        private readonly INotificationService _notificationService;
        private readonly IHistoryBuilder _historyBuilder;

        public CalculatorWindowPresenter(ICalculatorWindowView view, ICalculatorProcessor calculatorProcessor, ICalculatorStateService stateService, INotificationService notificationService)
        {
            _view = view;
            _calculatorProcessor = calculatorProcessor;
            _stateService = stateService;
            _notificationService = notificationService;
            _historyBuilder = new HistoryBuilder();
        }

        public void Show()
        {
            _view.InputChanged += InputFieldChangedHandler;
            _view.CalculateButtonClicked += CalculateButtonClickedHandler;
            _notificationService.WindowOpened += NotificationWindowOpenedHandler;
            _notificationService.WindowClosed += NotificationWindowClosedHandler;
            
            _view.SetInput(_stateService.GetInput());
            SetHistory(_stateService.GetHistory());
            _view.Show();
        }

        public void Hide()
        {
            _view.InputChanged -= InputFieldChangedHandler;
            _view.CalculateButtonClicked -= CalculateButtonClickedHandler;
            _notificationService.WindowOpened -= NotificationWindowOpenedHandler;
            _notificationService.WindowClosed -= NotificationWindowClosedHandler;
            
            _view.Hide();
        }

        private void SetHistory(IReadOnlyList<CalculationResultState> resultStates)
        {
            var history = _historyBuilder.Build(resultStates);
            _view.SetHistory(history);
        }

        private void Calculate()
        {
            var expression = _view.GetInput();
            var calculationResult = _calculatorProcessor.Calculate(expression);

            if (calculationResult.IsSuccess)
            {
                _view.SetInput(string.Empty);
            }
            else
            {
                ShowNotification(calculationResult.Message);
            }
            
            SetHistory(_stateService.GetHistory());
        }

        private void ShowNotification(string message)
        {
            _notificationService.OpenWindow(_view.GameObject.transform.parent, message);
        }

        private void InputFieldChangedHandler(object sender, EventArgs e)
        {
            _stateService.SetInput(_view.GetInput());
        }
        
        private void CalculateButtonClickedHandler(object sender, EventArgs e)
        {
            Calculate();
        }
        
        private void NotificationWindowOpenedHandler(object sender, EventArgs e)
        {
            _view.Hide();
        }
        
        private void NotificationWindowClosedHandler(object sender, EventArgs e)
        {
            _view.Show();
        }
    }
}