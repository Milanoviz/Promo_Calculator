using System;
using Modules.Notification.Scripts.UI;
using Modules.Notification.Scripts.UI.Presenter;
using Modules.Notification.Scripts.UI.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.Notification.Scripts
{
    public class NotificationService : INotificationService
    {
        public event EventHandler WindowOpened;
        public event EventHandler WindowClosed;
        
        private INotificationWindowPresenter _presenter;

        public void OpenWindow(Transform uiRoot, string message)
        {
            if (_presenter == null)
            {
                _presenter = CreatePresenter(uiRoot);
                _presenter.WindowOpened += WindowOpenedHandler;
                _presenter.WindowClosed += WindowClosedHandler;
            }
            
            _presenter.Show(message);
        }

        public void CloseWindow()
        {
            _presenter.Hide();
        }
        
        private INotificationWindowPresenter CreatePresenter(Transform root)
        {
            var viewPrefab = Resources.Load<NotificationWindowView>(AssetPath.WindowView);
            var view = Object.Instantiate(viewPrefab, root);
            
            return new NotificationWindowPresenter(view);
        }
        
        private void WindowOpenedHandler(object sender, EventArgs e)
        {
            WindowOpened?.Invoke(this, EventArgs.Empty);
        }
        
        private void WindowClosedHandler(object sender, EventArgs e)
        {
            WindowClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}