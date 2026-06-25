using System;

namespace Modules.Notification.Scripts.UI.Presenter
{
    public interface INotificationWindowPresenter
    {
        event EventHandler WindowOpened;
        event EventHandler WindowClosed;
        
        void Show(string message);
        void Hide();
    }
}