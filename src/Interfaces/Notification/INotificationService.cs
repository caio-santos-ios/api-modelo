using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface INotificationService
    {
        Task<ResponseApi<List<dynamic>>> GetByUserIdAsync(string userId, int limit = 30);
        Task<ResponseApi<int>> GetUnreadCountAsync(string userId);
        Task<ResponseApi<Notification?>> SendToUserAsync(CreateNotificationDTO dto);
        Task<ResponseApi<Notification?>> MarkAsReadAsync(string notificationId, string userId);
        Task MarkAllAsReadAsync(string userId);
        Task<ResponseApi<Notification>> DeleteAsync(string notificationId, string userId);
    }
}