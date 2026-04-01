using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;

namespace api_infor_cell.src.Interfaces
{
    public interface ITriggerService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<Trigger?>> CreateAsync(CreateTriggerDTO request);
        Task<ResponseApi<Trigger?>> UpdateAsync(UpdateTriggerDTO request);
        Task<ResponseApi<Trigger>> DeleteAsync(DeleteDTO request);
    }
}