using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Notification.Scripts.UI.View
{
    public class NotificationWindowView : MonoBehaviour, INotificationWindowView
    {
        public event EventHandler CloseButtonClicked;
        
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Button _closeButton;
        
        public void Show(string message)
        {
            _closeButton.onClick.AddListener(CloseButtonClickedHandler);

            SetMessage(message);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _closeButton.onClick.RemoveListener(CloseButtonClickedHandler);
            gameObject.SetActive(false);
        }

        private void SetMessage(string message)
        {
            _messageText.text = message;
        }

        private void CloseButtonClickedHandler()
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}