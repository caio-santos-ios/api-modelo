using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface IChatService
    {
        Task<ResponseApi<List<dynamic>>> GetConversationsAsync(string userId);
        Task<ResponseApi<List<dynamic>>> GetMessagesAsync(string conversationId, int page = 1, int pageSize = 50);
        Task<ResponseApi<ChatMessage?>> SendMessageAsync(SendChatMessageDTO dto);
        Task MarkConversationAsReadAsync(string conversationId, string userId);
        Task<ResponseApi<int>> GetUnreadCountAsync(string userId);
    }
}