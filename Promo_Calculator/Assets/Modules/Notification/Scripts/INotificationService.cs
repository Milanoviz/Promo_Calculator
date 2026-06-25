using System;
using UnityEngine;

namespace Modules.Notification.Scripts
{
    public interface INotificationService
    {
        event EventHandler WindowOpened;
        event EventHandler WindowClosed;
        
        void OpenWindow(Transform uiRoot, string message);
        void CloseWindow();
    }
}