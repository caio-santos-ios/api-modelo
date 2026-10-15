using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface IAttachmentService
    {
        Task<ResponseApi<PaginationApi<List<dynamic>>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Attachment?>> CreateAsync(CreateAttachmentDTO request);
        Task<ResponseApi<Attachment?>> UpdateAsync(UpdateAttachmentDTO request);
        Task<ResponseApi<Attachment>> DeleteAsync(string id);
    }
}