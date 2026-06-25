using System;

namespace Modules.Notification.Scripts.UI.View
{
    public interface INotificationWindowView
    {
        event EventHandler CloseButtonClicked;
        
        void Show(string message);
        void Hide();
    }
}