using System;
using Modules.Notification.Scripts.UI.View;

namespace Modules.Notification.Scripts.UI.Presenter
{
    public class NotificationWindowPresenter : INotificationWindowPresenter
    {
        public event EventHandler WindowOpened;
        public event EventHandler WindowClosed;
        
        private readonly INotificationWindowView _view;

        public NotificationWindowPresenter(INotificationWindowView view)
        {
            _view = view;
        }

        public void Show(string message)
        {
            _view.CloseButtonClicked += CloseButtonClickedHandler;
            _view.Show(message);
            OnWindowOpened();
        }

        public void Hide()
        {
            _view.CloseButtonClicked -= CloseButtonClickedHandler;
            _view.Hide();
            OnWindowClosed();
        }
        
        private void CloseButtonClickedHandler(object sender, EventArgs e)
        {
            Hide();
        }

        private void OnWindowOpened()
        {
            WindowOpened?.Invoke(this, EventArgs.Empty);
        }

        private void OnWindowClosed()
        {
            WindowClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}