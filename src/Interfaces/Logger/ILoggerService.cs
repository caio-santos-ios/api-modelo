using api_modelo.src.Models;
using api_modelo.src.Models.Base;
using api_modelo.src.Shared.DTOs;

namespace api_modelo.src.Interfaces
{
    public interface ILoggerService
    {
        Task<PaginationApi<List<dynamic>>> GetAllAsync(GetAllDTO request);
        Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id);
        Task<ResponseApi<Logger?>> CreateAsync(CreateLoggerDTO request);
        Task<ResponseApi<Logger?>> UpdateAsync(UpdateLoggerDTO request);
        Task<ResponseApi<Logger>> DeleteAsync(DeleteDTO request);
    }
}