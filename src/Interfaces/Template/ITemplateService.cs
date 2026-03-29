using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
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