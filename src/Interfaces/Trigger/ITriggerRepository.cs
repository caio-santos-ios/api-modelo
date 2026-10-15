using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;
using api_modelo.src.Shared.Utils;

namespace api_modelo.src.Interfaces
{
    public interface ITriggerRepository
    {
        Task<ResponseApi<List<dynamic>>> GetAllAsync(PaginationUtil<Trigger> pagination);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Trigger?>> GetByIdAsync(string id);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(PaginationUtil<Trigger> pagination);
        Task<int> GetCountDocumentsAsync(PaginationUtil<Trigger> pagination);
        Task<ResponseApi<Trigger?>> CreateAsync(Trigger trigger);
        Task<ResponseApi<Trigger?>> UpdateAsync(Trigger trigger);
        Task<ResponseApi<Trigger>> DeleteAsync(DeleteDTO request);
    }
}