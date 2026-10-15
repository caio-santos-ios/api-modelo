using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface ITemplateService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<Template?>> CreateAsync(CreateTemplateDTO request);
        Task<ResponseApi<Template?>> UpdateAsync(UpdateTemplateDTO request);
        Task<ResponseApi<Template?>> SendAsync(SendTemplateDTO request);
        Task<ResponseApi<Template>> DeleteAsync(DeleteDTO request);
    }
}