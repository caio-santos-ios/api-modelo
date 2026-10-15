using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;
using api_modelo.src.Shared.Utils;

namespace api_modelo.src.Interfaces
{
    public interface INotificationRepository
    {
        Task<ResponseApi<List<dynamic>>> GetByUserIdAsync(string userId, int limit = 30);
        Task<ResponseApi<int>> GetUnreadCountAsync(string userId);
        Task<ResponseApi<Notification?>> CreateAsync(Notification notification);
        Task<ResponseApi<Notification?>> MarkAsReadAsync(string notificationId, string userId);
        Task MarkAllAsReadAsync(string userId);
        Task<ResponseApi<Notification>> DeleteAsync(string notificationId, string userId);
    }
}