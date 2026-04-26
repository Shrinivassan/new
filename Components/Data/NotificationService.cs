using System;
using System.Threading.Tasks;

namespace Lims.Components.Data
{
    public enum NotificationType
    {
        Success,
        Info,
        Warning,
        Error
    }

    public class NotificationMessage
    {
        public NotificationType Type { get; set; } = NotificationType.Info;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        /// <summary>Milliseconds before the toast hides. Default 3000 (3s).</summary>
        public int Duration { get; set; } = 3000;
    }

    /// <summary>
    /// Simple, DI-friendly notification service that raises an event when pages/components want to show a toast.
    /// The UI component subscribes to <see cref="OnNotify"/> and displays the toast using Syncfusion SfToast.
    /// </summary>
    public class NotificationService
    {
        public event Func<NotificationMessage, Task>? OnNotify;

        private Task InvokeAsync(NotificationMessage message)
        {
            var handler = OnNotify;
            if (handler == null)
            {
                return Task.CompletedTask;
            }
            return handler.Invoke(message);
        }

        public Task ShowSuccess(string message, string? title = null, int duration = 3000)
            => InvokeAsync(new NotificationMessage { Type = NotificationType.Success, Title = title ?? "Success", Message = message, Duration = duration });

        public Task ShowInfo(string message, string? title = null, int duration = 3000)
            => InvokeAsync(new NotificationMessage { Type = NotificationType.Info, Title = title ?? "Info", Message = message, Duration = duration });

        public Task ShowWarning(string message, string? title = null, int duration = 3000)
            => InvokeAsync(new NotificationMessage { Type = NotificationType.Warning, Title = title ?? "Warning", Message = message, Duration = duration });

        public Task ShowError(string message, string? title = null, int duration = 4000)
            => InvokeAsync(new NotificationMessage { Type = NotificationType.Error, Title = title ?? "Error", Message = message, Duration = duration });

        public Task Show(NotificationMessage message)
            => InvokeAsync(message ?? new NotificationMessage());
    }
}
