// IChatRepository.cs
using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface IChatRepository
    {
        Task<ResponseApi<List<dynamic>>> GetConversationsAsync(string userId);
        Task<ResponseApi<List<dynamic>>> GetMessagesAsync(string conversationId, int page = 1, int pageSize = 50);
        Task<ResponseApi<ChatMessage?>> CreateMessageAsync(ChatMessage message);
        Task MarkConversationAsReadAsync(string conversationId, string userId);
        Task<ResponseApi<int>> GetUnreadCountAsync(string userId);
        Task<ResponseApi<Conversation?>> GetOrCreateConversationAsync(string userIdA, string userIdB);
        Task UpdateConversationLastMessageAsync(string conversationId, string lastMessage);
    }
}