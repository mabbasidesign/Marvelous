using Marvelous.Data;
using Marvelous.Models;
using Marvelous.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Marvelous.Repository
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly ApplicationDbContext _db;

        public NotificationRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            await _db.Notifications.AddAsync(notification);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync()
        {
            return await _db.Notifications.Where(n => !n.IsRead).ToListAsync();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _db.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _db.SaveChangesAsync();
            }
        }
    }
}
