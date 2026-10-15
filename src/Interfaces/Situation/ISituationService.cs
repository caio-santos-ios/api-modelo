using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface ISituationService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<List<dynamic>>> GetSelectAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Situation?>> CreateAsync(CreateSituationDTO request);
        Task<ResponseApi<Situation?>> UpdateAsync(UpdateSituationDTO request);
        Task<ResponseApi<Situation>> DeleteAsync(string id);
    }
}