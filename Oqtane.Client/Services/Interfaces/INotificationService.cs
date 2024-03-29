using Oqtane.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oqtane.Services
{ 
    /// <summary>
    /// Service to store and retrieve notifications (<see cref="Notification"/>)
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Return a list of notifications
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="direction"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Notification>> GetNotificationsAsync(int siteId, string direction, int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="direction"></param>
        /// <param name="userId"></param>
        /// <param name="count"></param>
        /// <param name="isRead"></param>
        /// <returns></returns>
        Task<List<Notification>> GetNotificationsAsync(int siteId, string direction, int userId, int count, bool isRead);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="direction"></param>
        /// <param name="userId"></param>
        /// <param name="isRead"></param>
        /// <returns></returns>
        Task<int> GetNotificationCountAsync(int siteId, string direction, int userId, bool isRead);

        /// <summary>
        /// Returns a specific notifications
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        Task<Notification> GetNotificationAsync(int notificationId);

        /// <summary>
        /// Creates a new notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        Task<Notification> AddNotificationAsync(Notification notification);

        /// <summary>
        /// Updates a existing notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        Task<Notification> UpdateNotificationAsync(Notification notification);

        /// <summary>
        /// Deletes a notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        Task DeleteNotificationAsync(int notificationId);
    }
}
