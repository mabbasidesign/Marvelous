using Marvelous.Models;

namespace Marvelous.Repository.IRepository
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification notification);
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync();
        Task MarkAsReadAsync(int notificationId);
    }
}
