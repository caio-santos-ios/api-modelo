using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
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